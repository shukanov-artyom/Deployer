using System;
using System.Collections.Generic;
using Deployer.Core.ActionItems;
using Deployer.Core.Filtering;
using Deployer.Core.Ordering;
using Deployer.Core.Sequence;

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
            this IEnumerable<DiffActionItem> sequence,
            ApplicationOptions options)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<string> ConvertToCmdCommands(
            this IEnumerable<DiffActionItem> orderedSequence)
        {
            throw new NotImplementedException();
        }

        public static void SaveToFile(
            this IEnumerable<string> lines,
            string targetFilePath)
        {
            throw new NotImplementedException();
        }
    }
}
