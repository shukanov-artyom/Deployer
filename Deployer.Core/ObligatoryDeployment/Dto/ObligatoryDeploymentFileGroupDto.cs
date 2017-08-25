using System.Collections.Generic;

namespace Deployer.Core.ObligatoryDeployment.Dto
{
    public class ObligatoryDeploymentFileGroupDto
    {
        public string SourceFolder { get; set; }

        public string TargetFolder { get; set; }

        public List<string> Filenames { get; set; }
    }
}
