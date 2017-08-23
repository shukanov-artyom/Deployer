using System;
using System.Collections.Generic;
using Deployer.Core.ActionItems;

namespace Deployer.Core.Ordering
{
    public class DefaultOrderingStrategy : IOrderingStrategy
    {
        private readonly Func<DiffActionItem, bool> addedFolders = 
            ai => ai.TargetType == DiffActionItemTargetType.Folder
                && ai.Action == DiffActionType.Added;

        private readonly Func<DiffActionItem, bool> addedFiles =
            ai => ai.TargetType == DiffActionItemTargetType.File
                  && ai.Action == DiffActionType.Added;

        private readonly Func<DiffActionItem, bool> modifiedFiles =
            ai => ai.TargetType == DiffActionItemTargetType.File
                  && ai.Action == DiffActionType.Modified;

        private readonly Func<DiffActionItem, bool> deletedFiles =
            ai => ai.TargetType == DiffActionItemTargetType.File
                  && ai.Action == DiffActionType.Deleted;

        private readonly Func<DiffActionItem, bool> deletedFolders =
            ai => ai.TargetType == DiffActionItemTargetType.Folder
                  && ai.Action == DiffActionType.Deleted;

        public IEnumerable<Func<DiffActionItem, bool>> Predicates
        {
            get
            {
                yield return addedFolders;
                yield return addedFiles;
                yield return modifiedFiles;
                yield return deletedFiles;
                yield return deletedFolders;
            }
        }
    }
}
