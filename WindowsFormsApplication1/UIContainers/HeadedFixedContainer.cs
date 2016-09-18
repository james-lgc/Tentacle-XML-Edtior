using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class HeadedFixedContainer : UIContainer
    {
        public GroupBox groupBox;

        public HeadedFixedContainer(Form1 form, TableLayoutPanel parentPanel, int rowNum, string labelText)
        {
            groupBox = new GroupBox();
            groupBox.AutoSize = true;
            groupBox.Text = labelText;
            groupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox.Dock = DockStyle.Fill;
            if (parentPanel != null)
            {
                groupBox.Parent = parentPanel;
                parentPanel.SetCellPosition(groupBox, new TableLayoutPanelCellPosition(rowNum, parentPanel.ColumnCount - 1));
                parentPanel.Controls.Add(groupBox);
            }
            else
            {
                form.Controls.Add(groupBox);
            }
        }

        public override void SetChildControls(CollapsableTable cTable)
        {
            cTable.panel.Parent = groupBox;
            groupBox.Controls.Add(cTable.panel);
        }
    }

}
