using System;
using System.Collections.Generic;

namespace Deployer.Core.ObligatoryDeployment
{
    public class ObligatoryDeploymentFileGroup
    {
        public string SourceFolder { get; set; }

        public string TargetFolder { get; set; }

        public List<string> Filenames { get; set; }
    }
}
