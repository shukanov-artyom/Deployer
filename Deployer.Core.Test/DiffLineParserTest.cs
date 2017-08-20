using System;
using Xunit;
using Deployer.Core.Sequence;

namespace Deployer.Core.Test
{
    public class DiffLineParserTest
    {
        [Fact]
        public void ParseAddedFolder()
        {
            string line = @" M      website\App_Code\JobBank";
            var parser = new DiffLineParser(line);
            Assert.Equal(parser.Item.Action, ActionItems.DiffActionType.Modified);
            Assert.Equal(parser.Item.TargetType, ActionItems.DiffActionItemTargetType.Folder);
            Assert.Equal(parser.Item.ItemRelativePath, "/App_Code/JobBank");
        }

        [Fact]
        public void ParseDeletedFile()
        {
            string line = @"D       website\App_Code\BusinessObjects\Comment.cs";
            var parser = new DiffLineParser(line);
            Assert.Equal(parser.Item.Action, ActionItems.DiffActionType.Modified);
            Assert.Equal(parser.Item.TargetType, ActionItems.DiffActionItemTargetType.Folder);
            Assert.Equal(parser.Item.ItemRelativePath, "/App_Code/JobBank");
        }
    }
}
