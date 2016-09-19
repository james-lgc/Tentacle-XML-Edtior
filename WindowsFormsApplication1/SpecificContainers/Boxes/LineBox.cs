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
        public HeadedFixedContainer container;
        ReplyTable replyTable;
        private Form1 form1;


        public LineBox(Form1 form, LineTable lineTable, int rowNum, Line line)
        {
            container = new HeadedFixedContainer(form, lineTable.cTable.panel, rowNum, null);
            lineTable.cTable.panel.SetColumn(container.groupBox, 1);
            lineTable.cTable.panel.SetRow(container.groupBox, rowNum);
            string[] labelTexts = new string[] { "Line" };
            container.AddHeading(form, lineTable.cTable, 1, null, false);
            container.textBoxes[0].DataBindings.Add("Text", line, "lineText", false, DataSourceUpdateMode.OnPropertyChanged);

            form1 = form;

            replyTable = new ReplyTable(form1, this, line.replies, line);

        }

    }
}
