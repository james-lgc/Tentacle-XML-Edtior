using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class CollapsableTable : UIContainer
    {
        public TableLayoutPanel panel;

        public CollapsableTable(Form1 form, UIContainer parent, int rowCount, int columnCount, int rowNum)
        {
            panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.BackColor = ColourManager.backGroundColour;
            //panel.AutoScroll = true;
           // panel.Show();
            panel.ColumnCount = columnCount;
            panel.RowCount = rowCount;
            parent.SetChildControls(this);
            TableSizer.AutoSize(panel);
            //panel.BackColor = System.Drawing.Color.Red;
            //parent.groupBox.SetRow(panel, rowNum);
            //parent.groupBox.SetColumn(panel, 0);
            //panel.BringToFront();
        }

        public override void SetChildControls(CollapsableTable cTable)
        {
            cTable.panel.Parent = panel;
            //panel.SetColumn(cTable.panel, 1);
            panel.Controls.Add(cTable.panel);
        }
    }
}
