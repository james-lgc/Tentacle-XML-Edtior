using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class LineTable : UITable<ConversationStage>
    {
        private LineBox lineBox;

        public LineTable(GroupBox groupBox, int rowCount, int columnCount, Line[] sentXArray, string extraText)
        {
            /*labelTexts = new string[] { "Line" };
            base.SetUp(form, dialogueBox.GroupBox1, lines.Length, 2, lines, "Line");
            for (int i = 0; i < xArray.Length; i++)
            {
                lineBox = new LineBox(form, this, i, xArray[i]);
                base.AddBox(lineBox);
            }*/
        }
        /*public override void AddRow(object sender, EventArgs e)
        {
            base.AddRow(sender, e);
            //TentacleLabel tLabel = new TentacleLabel("Line", cTable.panel.RowCount - 2, cTable.panel);
            //base.AddLabel(cTable.panel.RowCount - 2, "Line");
            NewX = new Line();
            NewX.Build();
            LineBox lineBox = new LineBox(form1, this, cTable.panel.RowCount - 1, NewX);
            boxes.Add(lineBox);
        }*/
    }
}
