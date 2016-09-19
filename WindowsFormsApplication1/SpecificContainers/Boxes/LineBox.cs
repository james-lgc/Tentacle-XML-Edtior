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
        //HeadedEditableContainer container;
        public CollapsableTable cTable;
        ReplyTable replyTable;
        private Form1 form1;


        public LineBox(Form1 form, LineTable lineTable, int rowNum, Line line)
        {
            //container = new HeadedEditableContainer(form, linetable.cTable.panel, rowNum, "Line", line.lineText, 0);
            //container.splitBox.textBox.DataBindings.Add("Text", line, "lineText", false, System.Windows.Forms.DataSourceUpdateMode.Never);
            cTable = new CollapsableTable(form, lineTable.cTable, 2, 1, rowNum);
            lineTable.cTable.panel.SetColumn(cTable.panel, 1);

            form1 = form;

            AddLine(lineTable, line);

            /*TextBox textBox = new TextBox();
            textBox.DataBindings.Add("Text", line, "lineText", false, DataSourceUpdateMode.OnPropertyChanged);
            textBox.Parent = cTable.panel;
            textBox.Dock = DockStyle.Fill;
            cTable.panel.SetRow(textBox, 0);
            linetable.cTable.panel.SetColumn(cTable.panel, 1);
            cTable.panel.Controls.Add(textBox);
            replyTable = new ReplyTable(form, this, line.replies, line);*/
        }

        public void AddLine(LineTable lineTable, Line line)
        {
            TextBox textBox = new TextBox();
            textBox.DataBindings.Add("Text", line, "lineText", false, DataSourceUpdateMode.OnPropertyChanged);
            textBox.Parent = cTable.panel;
            textBox.Dock = DockStyle.Fill;
            cTable.panel.SetRow(textBox, 0);
            lineTable.cTable.panel.SetColumn(cTable.panel, 1);
            cTable.panel.Controls.Add(textBox);
            replyTable = new ReplyTable(form1, this, line.replies, line);
        }
    }
}
