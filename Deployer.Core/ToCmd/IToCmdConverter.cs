using System;
using Deployer.Core.ActionItems;

namespace Deployer.Core.ToCmd
{
    public interface IToCmdConverter
    {
        string Convert(DiffActionItem item);
    }
}
