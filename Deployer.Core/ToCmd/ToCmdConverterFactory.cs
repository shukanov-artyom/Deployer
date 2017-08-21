using System;
using Deployer.Core.ActionItems;

namespace Deployer.Core.ToCmd
{
    public class ToCmdConverterFactory
    {
        private readonly DiffActionItem item;
        private readonly ApplicationOptions options;

        public ToCmdConverterFactory(
            ApplicationOptions options,
            DiffActionItem item)
        {
            this.item = item;
            this.options = options;
        }

        public IToCmdConverter Create()
        {
            if (item.TargetType == DiffActionItemTargetType.File &&
                item.Action == DiffActionType.Deleted)
            {
                return new FileDeletedToCmdConverter(options);
            }
            if (item.TargetType == DiffActionItemTargetType.File &&
                item.Action == DiffActionType.Added)
            {
                return new FileAddedToCmdConverter(options);
            }
            if (item.TargetType == DiffActionItemTargetType.File &&
                item.Action == DiffActionType.Modified)
            {
                return new FileModifiedToCmdConverter(options);
            }
            if (item.TargetType == DiffActionItemTargetType.Folder &&
                item.Action == DiffActionType.Added)
            {
                return new FolderAddedToCmdConverter(options);
            }
            if (item.TargetType == DiffActionItemTargetType.Folder &&
                item.Action == DiffActionType.Deleted)
            {
                return new FolderDeletedToCmdConverter(options);
            }
            throw new NotSupportedException("Item action not supported.");
        }
    }
}
