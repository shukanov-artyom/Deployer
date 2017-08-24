using System;
using System.IO;
using Deployer.Core.ActionItems;

namespace Deployer.Core.ToCmd
{
    public class FileDeletedToCmdConverter : ToCmdConverterBase, IToCmdConverter
    {
        private const string SshToolName = "plink";

        public FileDeletedToCmdConverter(ApplicationOptions options)
            : base(options)
        {
        }

        public string Convert(DiffActionItem item)
        {
            string targetAbsoluteFilePath =
                $"{Options.WebsiteRootFolder}/{item.ItemRelativePathTarget}";
            return $@"{SshToolName} -P {Options.ServerPort} -l {Options.UserName} -i {Options.Password} {Options.ServerAddress} rm -f {targetAbsoluteFilePath}";
        }
    }
}
