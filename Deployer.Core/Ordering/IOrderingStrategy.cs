using System;
using System.Collections.Generic;
using Deployer.Core.ActionItems;

namespace Deployer.Core.Ordering
{
    public interface IOrderingStrategy
    {
        IEnumerable<Func<DiffActionItem, bool>> Predicates { get; }
    }
}
