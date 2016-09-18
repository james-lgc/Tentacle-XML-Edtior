using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class LineBox : UIBox<Line>
    {
        HeadedEditableContainer container;
        CollapsableTable cTable;


        public LineBox(Form1 form, LineTable linetable, int rowNum, Line line)
        {
            //container = new HeadedEditableContainer(form, linetable.cTable.panel, rowNum, "Line", line.lineText, 0);
            //container.splitBox.textBox.DataBindings.Add("Text", line, "lineText", false, System.Windows.Forms.DataSourceUpdateMode.Never);
            cTable = new CollapsableTable(form, linetable.cTable, 2, 1, rowNum);

            TextBox textBox = new TextBox();
            textBox.DataBindings.Add("Text", line, "lineText", false, DataSourceUpdateMode.Never);
            textBox.Parent = cTable.panel;
            cTable.panel.SetRow(textBox, 0);
            cTable.panel.Controls.Add(textBox);
        }
    }
}
