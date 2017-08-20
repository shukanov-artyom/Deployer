using System;
using Deployer.Core.Filtering;
using Deployer.Core.FluentSyntax;
using Deployer.Core.Ordering;
using Deployer.Core.Sequence;

namespace Deployer.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var options = new ApplicationOptions(args);
            new DiffSequenceFactory(options).Create()
                .FilterSequence<DefaultFilterCollection>()
                .OrderSequence<DefaultOrderingStrategy>()
                .ConvertPathsToRemoteMachineFormat(options)
                .ConvertToCmdCommands()
                .SaveToFile(options.OutputDeploymentScenarioFilePath);
        }
    }
}
