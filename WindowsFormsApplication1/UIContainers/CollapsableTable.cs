using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class CollapsableTable
    {
        public TableLayoutPanel panel;

        public CollapsableTable(Form1 form, HeadedContainer parent, int rowCount, int rowNum)
        {
            panel = new TableLayoutPanel();
            parent.panel.Controls.Add(panel);
            panel.Dock = DockStyle.Fill;
            //panel.AutoScroll = true;
           // panel.Show();
            panel.ColumnCount = 1;
            panel.RowCount = rowCount;
            panel.Parent = parent.panel;
            //panel.BackColor = System.Drawing.Color.Red;
            parent.panel.SetRow(panel, rowNum);
            parent.panel.SetColumn(panel, 0);
            //panel.BringToFront();
        }
    }
}
