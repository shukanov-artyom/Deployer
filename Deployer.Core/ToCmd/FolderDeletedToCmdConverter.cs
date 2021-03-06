﻿using System;
using Deployer.Core.ActionItems;

namespace Deployer.Core.ToCmd
{
    public class FolderDeletedToCmdConverter : ToCmdConverterBase, IToCmdConverter
    {
        private const string SshToolName = "plink";

        public FolderDeletedToCmdConverter(ApplicationOptions options)
            : base(options)
        {
        }

        public string Convert(DiffActionItem item)
        {
            string targetAbsoluteFilePath =
                $"{Options.WebsiteRootFolder}/{item.ItemRelativePathTarget}";
            return $@"{SshToolName} -P {Options.ServerPort} -l {Options.UserName} -i {Options.Password} {Options.ServerAddress} rm -rf {targetAbsoluteFilePath}";
        }
    }
}
