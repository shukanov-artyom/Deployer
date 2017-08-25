using System;
using System.Collections.Generic;
using Deployer.Core.ObligatoryDeployment.Dto;

namespace Deployer.Core.ObligatoryDeployment
{
    public class ObligatoryDeploymentFileGroupAssembler
    {
        private readonly List<ObligatoryDeploymentFileGroupDto> fileGroups;
        private readonly List<ObligatoryDeploymentFolder> sourceFolders;
        private readonly List<ObligatoryDeploymentFolder> targetFolders;

        public ObligatoryDeploymentFileGroupAssembler(
            List<ObligatoryDeploymentFileGroupDto> fileGroups,
            List<ObligatoryDeploymentFolder> sourceFolders,
            List<ObligatoryDeploymentFolder> targetFolders)
        {
            this.fileGroups = fileGroups;
            this.sourceFolders = sourceFolders;
            this.targetFolders = targetFolders;
        }

        public List<ObligatoryDeploymentFileGroup> Assemble()
        {
            throw new NotImplementedException();
        }
    }
}
