﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class ReplyString : WrappedReply, IReturnable<string>
    {
        public new IReturnable<string>[] Returnables { get { return null; } set { } }
    }
}
