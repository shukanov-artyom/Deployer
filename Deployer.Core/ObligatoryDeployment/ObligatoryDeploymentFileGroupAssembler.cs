using System;
using System.Collections.Generic;
using System.Linq;
using Deployer.Core.ObligatoryDeployment.Dto;

namespace Deployer.Core.ObligatoryDeployment
{
    /// <summary>
    /// Assembles File group from DTO objects.
    /// </summary>
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
            Dictionary<string, string> sourceFoldersMapping =
                sourceFolders.ToDictionary(k => k.Id, v => v.Path);
            Dictionary<string, string> targetFoldersMapping =
                targetFolders.ToDictionary(k => k.Id, v => v.Path);
            var result = new List<ObligatoryDeploymentFileGroup>();
            foreach (var fileGroupDto in fileGroups)
            {
                var item = new ObligatoryDeploymentFileGroup();
                item.SourceFolder = sourceFoldersMapping[fileGroupDto.SourceFolder];
                item.TargetFolder = targetFoldersMapping[fileGroupDto.TargetFolder];
                foreach (var path in fileGroupDto.Filenames)
                {
                    item.Filenames.Add(path);
                }
                result.Add(item);
            }
            return result;
        }
    }
}
