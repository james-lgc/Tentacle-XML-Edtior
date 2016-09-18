using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class LineTable : UITable<Line>
    {
        public LineTable(Form1 form, DialogueBox dialogueBox, Line[] lines)
        {
            string[] labels = new string[] { "Lines" };
            base.SetUp(form, dialogueBox.container, lines.Length, 1, 1, lines, labels);
            for (int i = 0; i < xArray.Length; i++)
            {
                LineBox lineBox = new LineBox(form, this, i, lines[i]);
            }
            base.Expand();
            //cTable.panel.AutoScroll = true;
        }
    }
}
