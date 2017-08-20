using System;

namespace Deployer.Core
{
    public class DiffLineProcessorFactory
    {
        public DiffLineProcessorBase Create(
            ApplicationOptions options, 
            string changedFilePathName)
        {
            return new PscpDiffLineProcessor(changedFilePathName);
        }
    }
}
