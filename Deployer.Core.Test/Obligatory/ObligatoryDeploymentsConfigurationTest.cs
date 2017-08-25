using System;
using System.Collections.Generic;
using Deployer.Core.ObligatoryDeployment.Dto;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Deployer.Core.Test.Obligatory
{
    public class ObligatoryDeploymentsConfigurationTest : ObligatoryItemsTestBase
    {
        [Fact]
        public void TestCorrectJsonParsingSourceFolders()
        {
            IConfigurationSection section = GetSection("sourceFolders");
            var typed = section.Get<List<ObligatoryDeploymentFolder>>();
            Assert.True(typed.Count == 4);
            Assert.True(typed[0].Id == "bin");
            Assert.True(typed[0].Path == @"website\Bin\");
        }

        [Fact]
        public void TestCorrectJsonParsingTargetFolders()
        {
            IConfigurationSection section = GetSection("targetFolders");
            var typed = section.Get<List<ObligatoryDeploymentFolder>>();
            Assert.True(typed.Count == 4);
            Assert.True(typed[3].Id == "apiImagesCme");
            Assert.True(typed[3].Path == @"/cygdrive/d/Ftp-root/devapi.medbullets.com/images/cme");
        }

        [Fact]
        public void TestCorrectJsonParsingSourceFileGroups()
        {
            IConfigurationSection section = GetSection("sourceFileGroups");
            var typed = section.Get<List<ObligatoryDeploymentFileGroupDto>>();
            Assert.True(typed.Count == 4);
            Assert.True(typed[0].SourceFolder == "bin");
            Assert.True(typed[0].TargetFolder == "bin");
        }
    }
}
