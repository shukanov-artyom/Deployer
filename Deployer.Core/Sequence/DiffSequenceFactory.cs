using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Deployer.Core.ActionItems;

namespace Deployer.Core.Sequence
{
    public class DiffSequenceFactory
    {
        private readonly ApplicationOptions options;

        public DiffSequenceFactory(ApplicationOptions options)
        {
            this.options = options;
        }

        public IEnumerable<DiffActionItem> Create()
        {
            return File.ReadLines(options.DiffFilePath)
                .Select(diffLine => new DiffLineParser(options, diffLine).Item);
        }
    }
}
