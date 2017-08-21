using System;
using Deployer.Core.ActionItems;

namespace Deployer.Core.Filtering
{
    public class SqlScriptsFilter : IActionItemFilter
    {
        private const string PathSegment = @"website\database";

        public bool Fits(DiffActionItem item)
        {
            return !item.ItemRelativePath.ToUpper()
                .Contains(PathSegment.ToUpper());
        }
    }
}
