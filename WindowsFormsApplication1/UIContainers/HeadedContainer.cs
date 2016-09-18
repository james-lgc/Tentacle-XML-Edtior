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
            //panel.AutoScroll = true;
            //form.Controls.Add(panel);
            panel.Dock = DockStyle.Fill;
            
            panel.ColumnCount = 1;
            panel.RowCount = 2;
            //panel.BringToFront();
            //panel.Show();
            
            //panel.RowStyles.Add(new RowStyle(SizeType.Percent)); ;
            //panel.BackColor = System.Drawing.Color.Blue;
            if (parentPanel != null)
            {
                panel.Parent = parentPanel;
                parentPanel.Controls.Add(panel);
                parentPanel.SetRow(panel, rowNum);
                parentPanel.SetColumn(panel, 0);
                
            }
            else
            {
                form.Controls.Add(panel);
            }
        }

    }
}
