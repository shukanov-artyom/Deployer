using System;
using System.Collections.Generic;
using System.Linq;
using Deployer.Core.ActionItems;

namespace Deployer.Core.Filtering
{
    public class FiltrationEngine<TFilters>
        where TFilters : IEnumerable<IActionItemFilter>, new()
    {
        public IEnumerable<DiffActionItem> Filter(
            IEnumerable<DiffActionItem> sequence)
        {
            var filters = new TFilters().ToList();
            return sequence.Where(item => filters.TrueForAll(f => f.Fits(item)));
        }
    }
}
