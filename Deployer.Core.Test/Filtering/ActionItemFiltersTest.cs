using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Deployer.Core.ActionItems;
using Deployer.Core.Filtering;
using Xunit;

namespace Deployer.Core.Test.Filtering
{
    public class ActionItemFiltersTest
    {
        [Fact]
        public void FiltrationEngineTest()
        {
            var engine = new FiltrationEngine<TestFiltersCollection>();
            IEnumerable<DiffActionItem> sequence = new List<DiffActionItem>()
            {
                new DiffActionItem(DiffActionItemTargetType.File, DiffActionType.Added, "ValidPath"),
                new DiffActionItem(DiffActionItemTargetType.File, DiffActionType.Added, "AnotherPath"),
                new DiffActionItem(DiffActionItemTargetType.File, DiffActionType.Added, @"c:\SomeOtherPath")
            };
            Assert.Equal(engine.Filter(sequence).Count(), 1);
        }

        [Fact]
        public void SqlScriptsFilterTestPositive()
        {
            DiffActionItem item = new DiffActionItem(
                DiffActionItemTargetType.File,
                DiffActionType.Added,
                @"website\App_code\Views\CodeFile.cs");
            SqlScriptsFilter filter = new SqlScriptsFilter();
            bool result = filter.Fits(item);
            Assert.True(result);
        }

        [Fact]
        public void SqlScriptsFilterTestNegative()
        {
            DiffActionItem item = new DiffActionItem(
                DiffActionItemTargetType.File,
                DiffActionType.Added,
                @"website\database\script.sql");
            SqlScriptsFilter filter = new SqlScriptsFilter();
            bool result = filter.Fits(item);
            Assert.False(result);
        }

        [Fact]
        public void WebsiteContentsFilterTestPositive()
        {
            DiffActionItem item = new DiffActionItem(
                DiffActionItemTargetType.File,
                DiffActionType.Modified,
                @"Orthobullets.Assembly\Namespace\CodeFile.cs");
            var filter = new WebsiteFolderContentsFilter();
            bool result = filter.Fits(item);
            Assert.False(result);
        }

        [Fact]
        public void WebsiteContentsFilterTestNegative()
        {
            DiffActionItem item = new DiffActionItem(
                DiffActionItemTargetType.File,
                DiffActionType.Modified,
                @"website\App_Code\CodeFile.cs");
            var filter = new WebsiteFolderContentsFilter();
            bool result = filter.Fits(item);
            Assert.True(result);
        }

        private class TestFilter : IActionItemFilter
        {
            public bool Fits(DiffActionItem item)
            {
                return item.ItemRelativePathSource.ToUpper().Contains("VALIDPATH");
            }
        }

        private class TestFiltersCollection : IEnumerable<IActionItemFilter>
        {
            public IEnumerator<IActionItemFilter> GetEnumerator()
            {
                yield return new TestFilter();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
