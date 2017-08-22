using System;
using Deployer.Core.ActionItems;
using Deployer.Core.Filtering;
using Xunit;

namespace Deployer.Core.Test.Filtering
{
    public class WebConfigFilterTest
    {
        [Fact]
        public void TestPositive()
        {
            var item = new DiffActionItem(
                DiffActionItemTargetType.File,
                DiffActionType.Added,
                @"\website\relative\path\web.config")
            {
                ItemRelativePathTarget = "relative/path/some.another"
            };
            var filter = new WebConfigFilter();
            bool result = filter.Fits(item);
            Assert.False(result);
        }

        [Fact]
        public void TestNegative()
        {
            var item = new DiffActionItem(
                DiffActionItemTargetType.File,
                DiffActionType.Added,
                @"\website\relative\path\index.cshtml")
            {
                ItemRelativePathTarget = "relative/path/some.another"
            };
            var filter = new WebConfigFilter();
            bool result = filter.Fits(item);
            Assert.True(result);
        }
    }
}
