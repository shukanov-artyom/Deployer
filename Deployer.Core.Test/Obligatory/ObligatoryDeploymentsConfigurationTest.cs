using System;
using System.Collections.Generic;
using Deployer.Core.ObligatoryDeployment.Dto;
using Xunit;

namespace Deployer.Core.Test.Obligatory
{
    public class ObligatoryDeploymentsConfigurationTest : ObligatoryItemsTestBase
    {
        [Fact]
        public void TestCorrectJsonParsingSourceFolders()
        {
            var typed =
                GetTyped<List<ObligatoryDeploymentFolder>>("sourceFolders");
            Assert.True(typed.Count == 4);
            Assert.True(typed[0].Id == "bin");
            Assert.True(typed[0].Path == @"website\Bin\");
        }

        [Fact]
        public void TestCorrectJsonParsingTargetFolders()
        {
            var typed =
                GetTyped<List<ObligatoryDeploymentFolder>>("targetFolders");
            Assert.True(typed.Count == 4);
            Assert.True(typed[3].Id == "apiImagesCme");
            Assert.True(typed[3].Path == @"/cygdrive/d/Ftp-root/devapi.medbullets.com/images/cme");
        }

        [Fact]
        public void TestCorrectJsonParsingSourceFileGroups()
        {
            var typed =
                GetTyped<List<ObligatoryDeploymentFileGroupDto>>("sourceFileGroups");
            Assert.True(typed.Count == 4);
            Assert.True(typed[0].SourceFolder == "bin");
            Assert.True(typed[0].TargetFolder == "bin");
        }
    }
}
