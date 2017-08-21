using Deployer.Core.ActionItems;
using Deployer.Core.Sequence;
using Xunit;

namespace Deployer.Core.Test.Parsing
{
    public class ActionLetterParserTest
    {
        [Theory]
        [InlineData("M", DiffActionType.Modified)]
        [InlineData("D", DiffActionType.Deleted)]
        [InlineData("A", DiffActionType.Added)]
        public void TestLetterParser(string letter, DiffActionType action)
        {
            var parser = new ActionLetterParser(letter);
            Assert.Equal(parser.Action, action);
        }
    }
}
