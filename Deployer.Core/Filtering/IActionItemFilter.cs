using System;
using Deployer.Core.ActionItems;

namespace Deployer.Core.Filtering
{
    public interface IActionItemFilter
    {
        bool Fits(DiffActionItem item);
    }
}
