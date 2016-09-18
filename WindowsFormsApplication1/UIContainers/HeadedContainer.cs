using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class HeadedContainer : UIContainer
    {
        public TableLayoutPanel panel;
        protected int columnCount = 1;

        protected void SetUp(Form1 form, TableLayoutPanel parentPanel, int rowNum)
        {
            panel = new TableLayoutPanel();
            panel.RowCount = 2;
            panel.ColumnCount = columnCount;
            TableSizer.AutoSize(panel);
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

        public override void SetChildControls(CollapsableTable cTable)
        {
            cTable.panel.Parent = panel;
            panel.SetRow(cTable.panel, 1);
            panel.SetColumn(cTable.panel, panel.ColumnCount -1);
            panel.Controls.Add(cTable.panel);
        }


    }
}
