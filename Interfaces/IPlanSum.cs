﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESAPIX.Interfaces
{
    public interface IPlanSum : IPlanningItem
    {
        IStructureSet StructureSet { get; }

        IEnumerable<IPlanSetup> PlanSetups { get; }
    }
}