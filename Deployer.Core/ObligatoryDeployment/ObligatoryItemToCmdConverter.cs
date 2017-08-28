using System;
using System.IO;
using Deployer.Core.ActionItems;

namespace Deployer.Core.ObligatoryDeployment
{
    public class ObligatoryItemToCmdConverter
    {
        private const string ScpToolName = "pscp";

        private readonly ApplicationOptions options;

        public ObligatoryItemToCmdConverter(ApplicationOptions options)
        {
            this.options = options;
        }

        public string Convert(DiffActionItem item)
        {
            string fileToUploadAbsolutePath =
                Path.Combine(options.LocalSolutionRootPath,
                    item.ItemRelativePathSource);
            return $@"{ScpToolName} -P {options.ServerPort} -l {options.UserName} -i {options.Password} {fileToUploadAbsolutePath} {options.ServerAddress}:{item.ItemRelativePathTarget}";
        }
    }
}
