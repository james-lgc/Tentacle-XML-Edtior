﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public interface IReturnable<X>
    {
        IReturnable<X>[] Returnables { get; set; }

        //void Return();
    }
}
