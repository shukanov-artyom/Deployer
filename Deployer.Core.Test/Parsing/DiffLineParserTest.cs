using System;
using Deployer.Core.ActionItems;
using Deployer.Core.Sequence;
using Xunit;

namespace Deployer.Core.Test.Parsing
{
    public class DiffLineParserTest
    {
        [Theory]
        [InlineData(
            @" D      Tools\Database\MwpMigration\MigratorProc\Scripts",
            @"Tools\Database\MwpMigration\MigratorProc\Scripts",
            DiffActionType.Modified,
            DiffActionItemTargetType.Folder)]
        public void ParserTest(string line,
            string expectedPath,
            DiffActionType expectedAction,
            DiffActionItemTargetType expectedTarget)
        {
            var options = GetOptions();
            DiffLineParser parser = new DiffLineParser(options, line);
            var result = parser.Item;
            Assert.Equal(result.Action, expectedAction);
            Assert.Equal(result.ItemRelativePath, expectedPath);
            Assert.Equal(result.TargetType, expectedTarget);
        }

        private ApplicationOptions GetOptions()
        {
            return new ApplicationOptions(
                "address.server.com",
                "username",
                "userSecret",
                @"c:\WebsiteRootFolder",
                @"C:\diffs.txt",
                @"d:/output.txt",
                @"d:\dev\root");
        }
    }
}
