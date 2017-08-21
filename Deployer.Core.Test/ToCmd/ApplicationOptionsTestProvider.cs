using System;

namespace Deployer.Core.Test.ToCmd
{
    internal class ApplicationOptionsTestProvider
    {
        public ApplicationOptions Provide()
        {
            return new ApplicationOptions(
                serverAddress: "address.server.com",
                userName: "username",
                password: "userSecret",
                websiteRootFolder: @"/cygdrive/d/Ftp-root/responsive-design.orthobullets.com",
                diffFilePath: @"C:\diffs.txt",
                outputFilePath: @"d:\output.txt",
                localSolutionRootPath: @"C:\Local\Website\Directory");
        }
    }
}
