using System;
using Deployer.Core.ActionItems;
using Deployer.Core.ObligatoryDeployment;
using Deployer.Core.Test.ToCmd;
using Xunit;

namespace Deployer.Core.Test.Obligatory
{
    public class ObligatoryItemToCmdConverterTest
    {
        [Fact]
        public void TestCorrectness()
        {
            var options = new ApplicationOptionsTestProvider().Provide();
            DiffActionItem item =
                new DiffActionItem(
                    DiffActionItemTargetType.File,
                    DiffActionType.Modified,
                    @"C:\Local\Website\Directory\some\source\folder\filename.ext")
                {
                    ItemRelativePathTarget = @"/some/target/folder/filename.ext"
                };
            var result = new ObligatoryItemToCmdConverter(options).Convert(item);
            Assert.Equal(
                @"pscp -P 1234 -l username -i userSecret C:\Local\Website\Directory\some\source\folder\filename.ext address.server.com:/some/target/folder/filename.ext",
                result);
        }
    }
}
