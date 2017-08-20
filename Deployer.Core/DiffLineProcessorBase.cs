using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Deployer.Core
{
    public abstract class DiffLineProcessorBase
    {
        private static List<string> exclusionFolders =
            new List<string>()
            {
                @"website\database"
            };

        public DiffLineProcessorBase(string line)
        {
            if (String.IsNullOrEmpty(line))
            {
                throw new ArgumentException("Diff Line is null or empty.");
            }
            Line = line;
        }

        public string Line
        {
            get;
        }


        /// <summary>
        /// Abstract process method.
        /// </summary>
        public abstract string Process(ApplicationOptions options);

        protected bool IsLineExcluded(string diffLine)
        {
            return exclusionFolders.Any(diffLine.StartsWith);
        }

        protected static string ExtractTargetFolderPath(
            string filePathName,
            string websiteRootFolder)
        {
            if (Directory.Exists(filePathName))
            {
                // this is folder, throw out [website] segment.
                return filePathName.Substring(8);
            }
            string directory = Path.GetDirectoryName(filePathName);
            if (directory.StartsWith("website"))
            {
                if (directory.Length < 9) // if it is in a website folder directly
                {
                    return websiteRootFolder;
                }
                else
                {
                    directory = directory.Substring(8); // throw off website, take the rest
                }
            }
            // Prefix foldr is for our branch
            return Path.Combine(websiteRootFolder, directory);
        }
    }
}
