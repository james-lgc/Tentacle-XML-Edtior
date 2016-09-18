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
            parent.groupBox.Controls.Add(panel);
            panel.Dock = DockStyle.Fill;
            //panel.AutoScroll = true;
           // panel.Show();
            panel.ColumnCount = 1;
            panel.RowCount = rowCount;
            panel.Parent = parent.groupBox;
            //panel.BackColor = System.Drawing.Color.Red;
            //parent.groupBox.SetRow(panel, rowNum);
            //parent.groupBox.SetColumn(panel, 0);
            //panel.BringToFront();
        }
    }
}
