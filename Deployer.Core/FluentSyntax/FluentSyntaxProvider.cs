using System;
using System.Collections.Generic;
using System.IO;
using Deployer.Core.ActionItems;
using Deployer.Core.Filtering;
using Deployer.Core.ObligatoryDeployment;
using Deployer.Core.Ordering;
using Deployer.Core.PathConversion;
using Deployer.Core.ToCmd;
using Microsoft.Extensions.Configuration;

namespace Deployer.Core.FluentSyntax
{
    public static class FluentSyntaxProvider
    {
        public static IEnumerable<DiffActionItem> OrderSequence<TOrderingStrategy>(
            this IEnumerable<DiffActionItem> unorderedSequence)
            where TOrderingStrategy : IOrderingStrategy, new()
        {
            var factory = new DiffOrderedSequenceFactory(unorderedSequence);
            return factory.Create(new TOrderingStrategy());
        }

        public static IEnumerable<DiffActionItem> FilterSequence<TFilters>(
            this IEnumerable<DiffActionItem> collection)
            where TFilters : IEnumerable<IActionItemFilter>, new()
        {
            return new FiltrationEngine<TFilters>().Filter(collection);
        }

        public static IEnumerable<DiffActionItem> ConvertPathsToRemoteMachineFormat(
            this IEnumerable<DiffActionItem> sequence)
        {
            IEnumerable<IPathConversion> conversions = new List<IPathConversion>()
            {
                new ToWebsiteSubfolderConversion(),
                new ToUnixPathConversion()
            };
            PathConverter converter = new PathConverter(conversions);
            foreach (var item in sequence)
            {
                item.ItemRelativePathTarget =
                    converter.Convert(item.ItemRelativePathSource);
                yield return item;
            }
        }

        public static IEnumerable<string> ConvertToCmdCommands(
            this IEnumerable<DiffActionItem> orderedSequence,
            ApplicationOptions options)
        {
            foreach (var item in orderedSequence)
            {
                yield return new ToCmdConverterFactory(options, item).Create().Convert(item);
            }
        }

        public static IEnumerable<string> AppendObligatoryItems(
            this IEnumerable<string> orderedSequence,
            ApplicationOptions options)
        {
            // return all provided itemss
            foreach (string previous in orderedSequence)
            {
                yield return previous;
            }
            // append new items
            const string json = "obligatoryDeployments.json";
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile(json).Build();
            var obligatoryDeploymentsConfig =
                new ObligatoryDeploymentsConfiguration(builder.Build());
            foreach (var item in new ObligatoryActionItemsProvider(
                obligatoryDeploymentsConfig).Items)
            {
                yield return new ObligatoryItemToCmdConverter(options).Convert(item);
            }
        }

        public static void SaveToFile(
            this IEnumerable<string> lines,
            string targetFilePath)
        {
            File.WriteAllLines(targetFilePath, lines);
        }
    }
}
