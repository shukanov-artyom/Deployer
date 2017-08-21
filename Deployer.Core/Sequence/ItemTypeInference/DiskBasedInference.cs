using System;
using System.IO;
using Deployer.Core.ActionItems;

namespace Deployer.Core.Sequence.ItemTypeInference
{
    public class DiskBasedInference : IDiffActionItemTypeInference
    {
        private readonly ApplicationOptions options;

        public DiskBasedInference(ApplicationOptions options)
        {
            this.options = options;
        }

        public DiffActionItemTargetType Infer(string path)
        {
            string localSolutionRootPath = options.LocalSolutionRootPath;
            string localItemPath = Path.Combine(
                localSolutionRootPath,
                path);
            if (Directory.Exists(localItemPath))
            {
                return DiffActionItemTargetType.Folder;
            }
            if (File.Exists(localItemPath))
            {
                return DiffActionItemTargetType.File;
            }
            throw new NotSupportedException("Unrecognized item type.");
        }
    }
}
