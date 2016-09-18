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
            panel.Dock = DockStyle.Fill;
            panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            panel.AutoSizeMode = AutoSizeMode.GrowOnly;
            panel.Size = new System.Drawing.Size(70, 20);
            panel.RowStyles.Clear();
            panel.RowStyles.Add(new RowStyle(SizeType.Percent));
            panel.Show();
            panel.ColumnCount = 1;
            panel.RowCount = rowCount;
            panel.Parent = parent.panel;
            panel.BackColor = System.Drawing.Color.Red;
            parent.panel.SetRow(panel, rowNum);
            parent.panel.SetColumn(panel, 0);
            panel.BringToFront();
            parent.panel.Controls.Add(panel);
        }
    }
}
