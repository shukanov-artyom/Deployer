using System;
using System.Collections.Generic;
using System.Linq;
using Deployer.Core.ActionItems;
using Deployer.Core.ObligatoryDeployment;
using Xunit;

namespace Deployer.Core.Test.Obligatory
{
    public class ObligatoryActionItemsProviderTest : ObligatoryItemsTestBase
    {
        [Fact]
        public void TestCorrectness()
        {
            var config = GetConfiguration();
            var result = new ObligatoryActionItemsProvider(config).Items;
            List<DiffActionItem> actionItems = result.ToList();
            bool allFiles = actionItems.All(
                ai => ai.TargetType == DiffActionItemTargetType.File);
            Assert.True(allFiles);
            bool allModifieds = actionItems.All(
                ai => ai.Action == DiffActionType.Modified);
            Assert.True(allModifieds);
            bool hasRequiredItem =
                actionItems.Any(ai => ai.ItemRelativePathSource == "website\\Bin\\Orthobullets.Data.dll" &&
                                      ai.ItemRelativePathTarget == "/cygdrive/d/Ftp-root/responsive-design.orthobullets.com/Bin/Orthobullets.Data.dll");
            Assert.True(hasRequiredItem);
        }
    }
}
