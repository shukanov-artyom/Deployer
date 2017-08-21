using System;
using Deployer.Core.ActionItems;
using Deployer.Core.ToCmd;
using Xunit;

namespace Deployer.Core.Test.ToCmd
{
    public class FileModifiedToCmdConverterTest
    {
        [Fact]
        public void Test()
        {
            var item = new DiffActionItem(
                DiffActionItemTargetType.File,
                DiffActionType.Modified,
                @"App_Code/Views/View.cshtml"); // like it's changed by path modificator
            var options = new ApplicationOptionsTestProvider().Provide();
            string expectedResult =
                "pscp -P 2200 -l username -i userSecret C:\\Local\\Website\\Directory\\App_Code/Views/View.cshtml address.server.com:/cygdrive/d/Ftp-root/responsive-design.orthobullets.com/App_Code/Views/View.cshtml";
            var converter = new FileModifiedToCmdConverter(options);
            string result = converter.Convert(item);
            Assert.Equal(result, expectedResult);
        }
    }
}
