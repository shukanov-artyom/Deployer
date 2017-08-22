using System;
using Deployer.Core.ActionItems;

namespace Deployer.Core.Filtering
{
    public class WebConfigFilter : IActionItemFilter
    {
        private static readonly string ConfigMarker = "web.Config".ToUpper();

        public bool Fits(DiffActionItem item)
        {
            return !item.ItemRelativePathSource.ToUpper().EndsWith(ConfigMarker);
        }
    }
}
