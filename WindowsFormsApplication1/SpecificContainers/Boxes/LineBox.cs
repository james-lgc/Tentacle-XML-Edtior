using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class LineBox : UIBox<Line>
    {
        HeadedEditableContainer container;


        public LineBox(Form1 form, LineTable linetable, int rowNum, Line line)
        {
            container = new HeadedEditableContainer(form, linetable.cTable.panel, rowNum, "Line", line.lineText, 0);
            container.splitBox.textBox.DataBindings.Add("Text", line, "lineText", false, System.Windows.Forms.DataSourceUpdateMode.Never);
        }
    }
}
