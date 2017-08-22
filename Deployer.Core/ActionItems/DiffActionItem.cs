using System;

namespace Deployer.Core.ActionItems
{
    public class DiffActionItem
    {
        public DiffActionItem(
            DiffActionItemTargetType targetType,
            DiffActionType action,
            string itemRelativePathSource)
        {
            TargetType = targetType;
            Action = action;
            ItemRelativePathSource = itemRelativePathSource;
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
        /// Path as it should look like in a source environment (dev server local)
        /// </summary>
        public string ItemRelativePathSource
        {
            get;
        }

        /// <summary>
        /// Pure path as it should be in target system.
        /// Relative to web application root folder path.
        /// </summary>
        public string ItemRelativePathTarget
        {
            get;
            set;
        }
    }
}
