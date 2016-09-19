using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class LineTable : UITable<Line>
    {

        private LineBox lineBox;

        public LineTable(Form1 form, DialogueBox dialogueBox, Line[] lines)
        {
            string[] labels = new string[] { "Line" };
            base.SetUp(form, this, dialogueBox.container, lines.Length, 2, 1, lines, labels);
            for (int i = 0; i < xArray.Length; i++)
            {
                lineBox = new LineBox(form, this, i, lines[i]);
            }
            base.Expand();
        }

        public override void AddRow(object sender, EventArgs e)
        {
            base.AddRow(sender, e);
            base.AddLabel(cTable.panel.RowCount - 2, "Line");
            newX = new Line();
            newX.Build();
            LineBox lineBox = new LineBox(form1, this, cTable.panel.RowCount - 2, newX);
        }
    }
}
