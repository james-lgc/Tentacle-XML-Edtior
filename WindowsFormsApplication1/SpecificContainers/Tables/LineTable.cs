﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class LineTable : UITable<Line>
    {
        private LineBox lineBox;

        public LineTable(TentacleDoc form, DialogueBox dialogueBox, Line[] lines)
        {
            labelTexts = new string[] { "Line" };
            base.SetUp(form, this, dialogueBox.container, lines.Length, 2, lines, "Line");
            for (int i = 0; i < xArray.Length; i++)
            {
                lineBox = new LineBox(form, this, i, lines[i]);
                base.AddBox(lineBox);
            }
        }
        public override void AddRow(object sender, EventArgs e)
        {
            base.AddRow(sender, e);
            TentacleLabel tLabel = new TentacleLabel("Line", cTable.panel.RowCount - 2, cTable.panel);
            //base.AddLabel(cTable.panel.RowCount - 2, "Line");
            newX = new Line();
            newX.Build();
            LineBox lineBox = new LineBox(form1, this, cTable.panel.RowCount - 2, newX);
            boxes.Add(lineBox);
        }
    }
}
