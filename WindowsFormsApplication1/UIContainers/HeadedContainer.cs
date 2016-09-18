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
        public GroupBox groupBox;

        protected void SetUp(Form1 form, TableLayoutPanel parentPanel, int rowNum)
        {
            groupBox = new GroupBox();
            //panel.AutoScroll = true;
            //form.Controls.Add(panel);
            groupBox.Dock = DockStyle.Fill;
            groupBox.AutoSize = true;
            groupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //panel.BringToFront();
            //panel.Show();
            
            //panel.RowStyles.Add(new RowStyle(SizeType.Percent)); ;
            //panel.BackColor = System.Drawing.Color.Blue;
            if (parentPanel != null)
            {
                groupBox.Parent = parentPanel;
                parentPanel.Controls.Add(groupBox);
                parentPanel.SetRow(groupBox, rowNum);
                parentPanel.SetColumn(groupBox, 0);
                
            }
            else
            {
                form.Controls.Add(groupBox);
            }
        }

    }
}
