using System;
using Deployer.Core.ActionItems;
using Deployer.Core.Sequence.ItemTypeInference;

namespace Deployer.Core.Sequence
{
    public class DiffLineParser
    {
        private readonly string line;
        private readonly ApplicationOptions options;

        public DiffLineParser(
            ApplicationOptions options,
            string line)
        {
            this.line = line.Trim();
            this.options = options;
        }

        public DiffActionItem Item
        {
            get
            {
                string letter = line.Trim().Substring(0, 1);
                DiffActionType action = new ActionLetterParser(letter).Action;
                string path = line.Substring(1).Trim();
                IDiffActionItemTypeInference inference;
                if (action == DiffActionType.Deleted)
                {
                    inference = new HeuristicsInference();
                }
                else
                {
                    inference = new DiskBasedInference(options, path);
                }
                DiffActionItemTargetType target = inference.Infer();
                throw new NotImplementedException("Path should be retrieved here");
                return new DiffActionItem(target, action, path);
            }
        }
    }
}
