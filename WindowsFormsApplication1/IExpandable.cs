﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public interface IExpandable
    {
        bool isExpanded { get; set; }
        CollapsableTable cTable { get; set; }

        void ToggleExpansion();
    }
}
