using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class HeadedContainer
    {
        public TableLayoutPanel panel;

        protected void SetUp(Form1 form, TableLayoutPanel parentPanel, int rowNum)
        {
            panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            form.Controls.Add(panel);
            panel.ColumnCount = 1;
            panel.RowCount = 2;
            panel.AutoSizeMode = AutoSizeMode.GrowOnly;
            panel.Size = new System.Drawing.Size(70, 20);
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.BringToFront();
            panel.RowStyles.Clear();
            panel.Show();
            panel.RowStyles.Add(new RowStyle(SizeType.Percent)); ;
            panel.BackColor = System.Drawing.Color.Blue;
            if (parentPanel != null)
            {
                panel.Parent = parentPanel;
                parentPanel.SetRow(panel, rowNum);
                parentPanel.SetColumn(panel, 0);
                parentPanel.Controls.Add(panel);
            }
            else
            {
                form.Controls.Add(panel);
                
            }
        }

    }
}
