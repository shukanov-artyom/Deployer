using System;
using System.IO;
using Deployer.Core.ActionItems;
using Deployer.Core.Sequence.ItemTypeInference;
using Xunit;

namespace Deployer.Core.Test.Parsing.Inference
{
    public class InferenceTest
    {
        [Theory]
        [InlineData(
            @"website\Comments\Controls\ComentSectionControl.ascx.cs",
            DiffActionItemTargetType.File)]
        [InlineData(
            @"website\Comments\Controls",
            DiffActionItemTargetType.Folder)]
        public void TestHeuristicInference(
            string input,
            DiffActionItemTargetType expectedType)
        {
            var options = GetTestOptions();
            var inference = new HeuristicsInference(options);
            var result = inference.Infer(input);
            Assert.Equal(result, expectedType);
        }

        [Fact]
        public void TestDiskBasedInference()
        {
            string currentDir = Directory.GetCurrentDirectory();
            var options = new ApplicationOptions(
                "address.server.com",
                "username",
                "userSecret",
                @"c:\WebsiteRootFolder",
                @"C:\diffs.txt",
                @"d:/output.txt",
                currentDir,
                serverPort: 1234);
            var inference = new DiskBasedInference(options);
            // we are pretty sure this file must be there
            var result = inference.Infer("Deployer.Core.Test.dll");
            Assert.Equal(result, DiffActionItemTargetType.File);
        }

        private ApplicationOptions GetTestOptions()
        {
            return new ApplicationOptions(
                "address.server.com",
                "username",
                "userSecret",
                @"c:\WebsiteRootFolder",
                @"C:\diffs.txt",
                @"d:/output.txt",
                @"d:\dev\root",
                serverPort: 1234);
        }
    }
}
