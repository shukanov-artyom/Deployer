using System;
using Deployer.Core.ActionItems;

namespace Deployer.Core.Sequence
{
    public class ActionLetterParser
    {
        private readonly string letter;

        public ActionLetterParser(string letter)
        {
            if (letter.Length > 1)
            {
                throw new ArgumentException(
                    "Type of action must be repreesented by a single letter.");
            }
            this.letter = letter.ToUpper();
        }

        public DiffActionType Action
        {
            get
            {
                switch (letter)
                {
                    case "M":
                        return DiffActionType.Modified;
                    case "A":
                        return DiffActionType.Added;
                    case "D":
                        return DiffActionType.Deleted;
                    default:
                        throw new NotSupportedException(
                            $"Action letter {letter} is not supported.");
                }
            }
        }
    }
}
