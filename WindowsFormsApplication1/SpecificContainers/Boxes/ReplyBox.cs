﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class RepliesBox : UIBox<WrappedReply<ReplyString<string>>, ReplyString<string>>
    {
        public override int Fields { get { return 1; } }
        public override string[] LabelTexts { get { return new string[] { "Reply" }; } }
        public override bool IsCollapsable { get { return false; } }
        public override int[] NumFields { get { return null; } }

        public RepliesBox(WrappedReply<ReplyString<string>> sentX, TentacleDoc form, ReplyTable parentTable, int rowNum, string labelText, int columnCount, string extraText) : base(sentX, form, parentTable, rowNum, labelText, columnCount, extraText)
        {
            //base.SetUp(reply, form, replyTable, rowNum, null);
            //base.AssignTable(null);
            //BoxHeading.InputControls[0].DataBindings.Add("Text", ThisX, "WrappedReply1", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        /*public override WrappedReply ReturnX()
        {
            return base.ReturnX();
        }*/
    }
}
