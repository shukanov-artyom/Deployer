using System;

namespace Deployer.Core.ActionItems
{
    public class DiffActionItem
    {
        public DiffActionItem(
            DiffActionItemTargetType targetType,
            DiffActionType action,
            string itemRelativePath)
        {
            TargetType = targetType;
            Action = action;
            ItemRelativePath = itemRelativePath;
        }

        public DiffActionItemTargetType TargetType
        {
            get;
        }

        public DiffActionType Action
        {
            get;
        }

        /// <summary>
        /// Pure path as it should be in target system.
        /// Relative to web application root folder path.
        /// </summary>
        public string ItemRelativePath
        {
            get;
        }
    }
}
