using System;
using System.Collections.Generic;

namespace Deployer.Core.ObligatoryDeployment
{
    public class ObligatoryDeploymentFileGroup
    {
        public ObligatoryDeploymentFileGroup()
        {
            Filenames = new List<string>();
        }

        public string SourceFolder { get; set; }

        public string TargetFolder { get; set; }

        public List<string> Filenames { get; }
    }
}
