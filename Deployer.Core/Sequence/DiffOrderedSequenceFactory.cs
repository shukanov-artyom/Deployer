﻿using System;
using System.Collections.Generic;
using System.Linq;
using Deployer.Core.ActionItems;
using Deployer.Core.Ordering;

namespace Deployer.Core.Sequence
{
    public class DiffOrderedSequenceFactory
    {
        private readonly IEnumerable<DiffActionItem> unorderedSequence;

        public DiffOrderedSequenceFactory(IEnumerable<DiffActionItem> unorderedSequence)
        {
            this.unorderedSequence = unorderedSequence;
        }

        public IEnumerable<DiffActionItem> Create(IOrderingStrategy orderingStrategy)
        {
            foreach (var predicate in orderingStrategy.Predicates)
            {
                foreach (var item in unorderedSequence.Where(predicate))
                {
                    yield return item;
                }
            }
        }
    }
}
