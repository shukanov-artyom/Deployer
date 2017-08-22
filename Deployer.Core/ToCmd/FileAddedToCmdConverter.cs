using System;
using System.IO;
using Deployer.Core.ActionItems;

namespace Deployer.Core.ToCmd
{
    public class FileAddedToCmdConverter : ToCmdConverterBase, IToCmdConverter
    {
        private const string ScpToolName = "pscp";

        public FileAddedToCmdConverter(ApplicationOptions options)
            : base(options)
        {
        }

        public string Convert(DiffActionItem item)
        {
            string fileToUploadAbsolutePath =
                Path.Combine(Options.LocalSolutionRootPath,
                    item.ItemRelativePathSource);
            string targetAbsoluteFilePath =
                $"{Options.WebsiteRootFolder}/{item.ItemRelativePathTarget}";
            return $@"{ScpToolName} -P 2200 -l {Options.UserName} -i {Options.Password} {fileToUploadAbsolutePath} {Options.ServerAddress}:{targetAbsoluteFilePath}";
        }
    }
}
