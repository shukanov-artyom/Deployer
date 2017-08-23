using System;
using Deployer.Core.ActionItems;
using Deployer.Core.ToCmd;
using Xunit;

namespace Deployer.Core.Test.ToCmd
{
    public class FileDeletedToCmdConverterTest
    {
        [Fact]
        public void Test()
        {
            var options = new ApplicationOptionsTestProvider().Provide();
            var converter = new FileDeletedToCmdConverter(options);
            var item = new DiffActionItem(
                DiffActionItemTargetType.File,
                DiffActionType.Deleted,
                @"App_Code\Views\View.cshtml")
            {
                ItemRelativePathTarget = @"App_Code/Views/View.cshtml"
            };
            string expectedResult =
                "plink -P 2200 -l username -i userSecret address.server.com rm -f /cygdrive/d/Ftp-root/responsive-design.orthobullets.com/App_Code/Views/View.cshtml";
            string result = converter.Convert(item);
            Assert.Equal(result, expectedResult);
        }
    }
}
