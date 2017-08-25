using System;
using System.Collections.Generic;
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
                throw new NotImplementedException();
                //config.Get
            }
        }
    }
}
