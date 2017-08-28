using System;
using System.Collections.Generic;
using Deployer.Core.ObligatoryDeployment;
using Deployer.Core.ObligatoryDeployment.Dto;
using Xunit;

namespace Deployer.Core.Test.Obligatory
{
    public class ObligatoryDeploymentFileGroupAssemblerTest : ObligatoryItemsTestBase
    {
        [Fact]
        public void TestAssemblyCorrectness()
        {
            var groupDtos =
                GetTyped<List<ObligatoryDeploymentFileGroupDto>>("sourceFileGroups");
            var sourceFolders =
                GetTyped<List<ObligatoryDeploymentFolder>>("sourceFolders");
            var targetFolders =
                GetTyped<List<ObligatoryDeploymentFolder>>("targetFolders");
            var assembler = new ObligatoryDeploymentFileGroupAssembler(
                groupDtos,
                sourceFolders,
                targetFolders);
            var result = assembler.Assemble();
            Assert.NotNull(result);
            var group = result[0];
            Assert.Equal("website\\Bin\\", group.SourceFolder);
            Assert.Equal("/cygdrive/d/Ftp-root/responsive-design.orthobullets.com/Bin", group.TargetFolder);
            Assert.Equal(7, group.Filenames.Count);
        }
    }
}
