﻿using System;
using Deployer.Core.ActionItems;

namespace Deployer.Core.Filtering
{
    public class WebsiteFolderContentsFilter : IActionItemFilter
    {
        private const string PathObligatorySegment = "website";

        public bool Fits(DiffActionItem item)
        {
            return item.ItemRelativePath.ToUpper()
                .Contains(PathObligatorySegment.ToUpper());
        }
    }
}
