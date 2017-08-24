using System;

namespace Deployer.Core
{
    public class ApplicationOptions
    {
        public ApplicationOptions(string[] args)
        {
            ServerAddress = args[0];
            UserName = args[1];
            Password = args[2];
            WebsiteRootFolder = args[3];
            DiffFilePath = args[4];
            OutputDeploymentScenarioFilePath = args[5];
            LocalSolutionRootPath = args[6];
            ServerPort = Int32.Parse(args[7]);
        }

        public ApplicationOptions(
            string serverAddress,
            string userName,
            string password,
            string websiteRootFolder,
            string diffFilePath,
            string outputFilePath,
            string localSolutionRootPath,
            int serverPort)
        {
            ServerAddress = serverAddress;
            UserName = userName;
            Password = password;
            WebsiteRootFolder = websiteRootFolder;
            DiffFilePath = diffFilePath;
            OutputDeploymentScenarioFilePath = outputFilePath;
            LocalSolutionRootPath = localSolutionRootPath;
            ServerPort = serverPort;
        }

        /// <summary>
        /// DNS Address of a server to upload files to.
        /// </summary>
        public string ServerAddress { get; }

        /// <summary>
        /// Port to connect to server.
        /// </summary>
        public int ServerPort { get; }

        /// <summary>
        /// Username to supply to SSH tool.
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// Password OR path to private key to supply to SSH tools.
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Root folder of a Web App on a target system.
        /// Example: /cygdrive/d/Ftp-root/responsive-design.orthobullets.com
        /// </summary>
        public string WebsiteRootFolder { get; }

        /// <summary>
        /// Path to SVN-generated diff file.
        /// </summary>
        public string DiffFilePath { get; }

        /// <summary>
        /// Where to place generated deployment scenario.
        /// </summary>
        public string OutputDeploymentScenarioFilePath { get; }

        /// <summary>
        /// Local solution root path. Current local working folder.
        /// </summary>
        public string LocalSolutionRootPath { get; }
    }
}
