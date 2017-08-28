using System;
using System.Collections.Generic;
using Deployer.Core.ObligatoryDeployment.Dto;
using Microsoft.Extensions.Configuration;

namespace Deployer.Core.ObligatoryDeployment
{
    public class ObligatoryDeploymentsConfiguration
    {
        private readonly IConfiguration config;

        public ObligatoryDeploymentsConfiguration(IConfiguration config)
        {
            this.config = config;
        }

        public IEnumerable<ObligatoryDeploymentFileGroup> Groups
        {
            get
            {
                return new ObligatoryDeploymentFileGroupAssembler(
                    GetTyped<List<ObligatoryDeploymentFileGroupDto>>("sourceFileGroups"),
                    GetTyped<List<ObligatoryDeploymentFolder>>("sourceFolders"),
                    GetTyped<List<ObligatoryDeploymentFolder>>("targetFolders"))
                    .Assemble();
            }
        }

        protected TType GetTyped<TType>(string sectionName) where TType : class
        {
            var section = config.GetSection(sectionName);
            return section.Get<TType>();
        }
    }
}
