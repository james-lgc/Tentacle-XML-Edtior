﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class RepliesBox : UIBox<string>
    {
        public RepliesBox(Form1 form, ReplyTable replyTable, int rowNum, string reply)
        {
            base.SetUp(reply);
        }

        public override string ReturnX()
        {
            return base.ReturnX();
        }
    }
}
