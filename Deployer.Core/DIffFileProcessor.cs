using System;
using System.IO;
using Deployer.Core;

namespace DiffToFtp2
{
    public class DiffFileProcessor
    {
        private const string WebsiteSubstring = @"website\";

        private readonly ApplicationOptions options;

        private readonly FileStream diffFileStream;
        private readonly FileStream outputScenarioStream;

        public DiffFileProcessor(
            ApplicationOptions options,
            FileStream diffFileStream, 
            FileStream outputScenarioStream)
        {
            this.options = options;
            this.diffFileStream = diffFileStream;
            this.outputScenarioStream = outputScenarioStream;
        }

        public void Process()
        {
            using (StreamReader r = new StreamReader(diffFileStream))
            using (StreamWriter writer = new StreamWriter(outputScenarioStream))
            {
                while (!r.EndOfStream)
                {
                    string line = r.ReadLine();
                    string changedFilePathName = line.Substring(8);
                    if (PathNameFits(changedFilePathName))
                    {
                        string resultLine = ProcessDiffLine(line);
                        if (!String.IsNullOrEmpty(resultLine))
                        {
                            writer.WriteLine(resultLine);
                        }
                    }
                }
                writer.Flush();
            }
        }

        private bool PathNameFits(string pathName)
        {
            if (pathName.ToUpper().EndsWith("WEB.CONFIG"))
            {
                return false;
            }
            return pathName.Contains(WebsiteSubstring);
        }

        private string ProcessDiffLine(string diffLine)
        {
            var factory = new DiffLineProcessorFactory();
            DiffLineProcessorBase lineProcessor = 
                factory.Create(options, diffLine);
            string ftpScriptLine = lineProcessor.Process(options);
            return ftpScriptLine;
        }
    }
}