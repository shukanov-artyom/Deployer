using System;
using Deployer.Core.ActionItems;
using Deployer.Core.ToCmd;
using Xunit;

namespace Deployer.Core.Test.ToCmd
{
    public class FolderDeletedToCmdConverterTest
    {
        [Fact]
        public void Test()
        {
            var item = new DiffActionItem(
                DiffActionItemTargetType.Folder,
                DiffActionType.Deleted,
                @"App_Code\Views")
            {
                ItemRelativePathTarget = @"App_Code/Views"
            }; // like it's changed by path modificator
            var options = new ApplicationOptionsTestProvider().Provide();
            string expectedResult =
                "plink -P 1234 -l username -i userSecret address.server.com rm -rf /cygdrive/d/Ftp-root/responsive-design.orthobullets.com/App_Code/Views";
            var converter = new FolderDeletedToCmdConverter(options);
            string result = converter.Convert(item);
            Assert.Equal(result, expectedResult);
        }
    }
}
