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
        public HeadedFixedContainer container;
        //public CollapsableTable cTable;
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
            //container.splitBox.textBox.DataBindings.Add("Text", line, "lineText", false, System.Windows.Forms.DataSourceUpdateMode.Never);
            //cTable = new CollapsableTable(form, lineTable.cTable, 2, 1, rowNum);
            //lineTable.cTable.panel.SetColumn(cTable.panel, 1);

            form1 = form;

            replyTable = new ReplyTable(form1, this, line.replies, line);

            //AddLine(lineTable, line);

            /*TextBox textBox = new TextBox();
            textBox.DataBindings.Add("Text", line, "lineText", false, DataSourceUpdateMode.OnPropertyChanged);
            textBox.Parent = cTable.panel;
            textBox.Dock = DockStyle.Fill;
            cTable.panel.SetRow(textBox, 0);
            linetable.cTable.panel.SetColumn(cTable.panel, 1);
            cTable.panel.Controls.Add(textBox);
            replyTable = new ReplyTable(form, this, line.replies, line);*/
        }

        /*public void AddLine(LineTable lineTable, Line line)
        {
            TextBox textBox = new TextBox();
            textBox.DataBindings.Add("Text", line, "lineText", false, DataSourceUpdateMode.OnPropertyChanged);
            textBox.Parent = cTable.panel;
            textBox.Dock = DockStyle.Fill;
            cTable.panel.SetRow(textBox, 0);
            lineTable.cTable.panel.SetColumn(cTable.panel, 1);
            cTable.panel.Controls.Add(textBox);
            replyTable = new ReplyTable(form1, this, line.replies, line);
        }*/
    }
}
