using System;
using System.Collections.Generic;
using System.Linq;
using Deployer.Core.ActionItems;
using Deployer.Core.Ordering;
using Xunit;

namespace Deployer.Core.Test.Ordering
{
    public class OrderingStrategyTest
    {
        [Fact]
        public void TestDefaultOrderingStrategy()
        {
            List<DiffActionItem> unorderedSequence =
                new List<DiffActionItem>()
                {
                    new DiffActionItem(DiffActionItemTargetType.File, DiffActionType.Modified, "name"),
                    new DiffActionItem(DiffActionItemTargetType.File, DiffActionType.Deleted, "name"),
                    new DiffActionItem(DiffActionItemTargetType.File, DiffActionType.Modified, "name"),
                    new DiffActionItem(DiffActionItemTargetType.Folder, DiffActionType.Modified, "name"),
                    new DiffActionItem(DiffActionItemTargetType.Folder, DiffActionType.Added, "name")
                };
            var factory = new DiffOrderedSequenceFactory(unorderedSequence);
            List<DiffActionItem> result = 
                factory.Create(new DefaultOrderingStrategy()).ToList();
            Assert.Equal(result.Count, 4);
            Assert.Equal(result[0].TargetType, DiffActionItemTargetType.Folder);
            Assert.Equal(result[0].Action, DiffActionType.Added);
        }
    }
}
