﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class LineBox : UIBox<Line>
    {
        //public HeadedFixedContainer container;
        ReplyTable replyTable;
        private TentacleDoc form1;


        public LineBox(TentacleDoc form, LineTable lineTable, int rowNum, Line line)
        {
            base.SetUp(line, form, lineTable.cTable.panel, rowNum, null);
            //container = new HeadedFixedContainer(form, lineTable.cTable.panel, rowNum, null);
            lineTable.cTable.panel.SetColumn(GroupBox1, 1);
            lineTable.cTable.panel.SetRow(GroupBox1, rowNum);
            string[] labelTexts = new string[] { "Speech" };

            form1 = form;

            replyTable = new ReplyTable(form1, this, line.replies, line);
            base.AddHeading(form, replyTable.cTable, 1, null, true);
            //container.AddHeading(form, replyTable.cTable, 1, null, true);
            TextBoxes[0].DataBindings.Add("Text", line, "lineText", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public override Line ReturnX()
        {
            string[] replies = replyTable.ReturnContents;
            thisX.replies = replies;
            return base.ReturnX();
        }

    }
}
