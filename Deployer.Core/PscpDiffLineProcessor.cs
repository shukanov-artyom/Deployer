using System;

namespace Deployer.Core
{
    public class PscpDiffLineProcessor : DiffLineProcessorBase
    {
        private const string ScpToolName = @"pscp";
        private const string SshToolName = @"plink";

        public PscpDiffLineProcessor(string line)
            : base(line)
        {
        }

        public override string Process(ApplicationOptions options)
        {
            if (IsLineExcluded(Line))
            {
                return String.Empty; // we do not need excluded folder contents
            }
            string websiteFolder = ExtractTargetFolderPath(Line, options.WebsiteRootFolder);
            string fileToUploadLocalPathName = Line;
            // pscp -P 2200 -l Administrator -pw soMePwD web.config branch2.orthobullets.com:/cygdrive/d/ftp-root
            // pscp -P 2200 -l Administrator -i file.ppk web.config branch2.orthobullets.com:/cygdrive/d/ftp-root

            return $@"@echo off
if exist {fileToUploadLocalPathName}\ (
    echo {fileToUploadLocalPathName} is a folder, attempting to create
    {SshToolName} -P 2200 -l {options.UserName} -i {options.Password} {options.ServerAddress} mkdir -p {websiteFolder}
) else if exist {fileToUploadLocalPathName} (
    echo Deploying file {fileToUploadLocalPathName} 
    {ScpToolName} -P 2200 -l {options.UserName} -i {options.Password} {fileToUploadLocalPathName} {options.ServerAddress}:{websiteFolder}
) else (
    echo {fileToUploadLocalPathName} does not exist, skipping deployment for it
)";
        }
    }
}
