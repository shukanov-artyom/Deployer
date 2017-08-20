using System;
using System.IO;
using Deployer.Core.ActionItems;

namespace Deployer.Core.Sequence.ItemTypeInference
{
    public class DiskBasedInference : IDiffActionItemTypeInference
    {
        private readonly string linePathPart;
        private readonly ApplicationOptions options;

        public DiskBasedInference(
            ApplicationOptions options,
            string linePathPart)
        {
            this.linePathPart = linePathPart;
            this.options = options;
        }

        public DiffActionItemTargetType TargetType
        {
            get
            {
                string localSolutionRootPath = options.LocalSolutionRootPath;
                string localItemPath = Path.Combine(
                    localSolutionRootPath,
                    linePathPart);
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

        public DiffActionItemTargetType Infer()
        {
            throw new NotImplementedException();
        }
    }
}
