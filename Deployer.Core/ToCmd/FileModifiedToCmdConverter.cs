using System;

namespace Deployer.Core.ToCmd
{
    public class FileModifiedToCmdConverter : FileAddedToCmdConverter
    {
        public FileModifiedToCmdConverter(ApplicationOptions options)
            : base(options)
        {
        }
    }
}
