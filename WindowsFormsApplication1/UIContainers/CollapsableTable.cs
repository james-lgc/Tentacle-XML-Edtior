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

        public CollapsableTable(TentacleDoc form, GroupBox parent, int rowCount, int columnCount)
        {
            panel = new TableLayoutPanel();
            panel.Parent = parent;
            parent.Controls.Add(panel);
            panel.Dock = DockStyle.Fill;
            panel.BackColor = ColourManager.backGroundColour;
            panel.ColumnCount = columnCount;
            panel.RowCount = rowCount;
            //parent.SetChildControls(this);
            TableSizer.AutoSize(panel);
        }

        public override void SetChildControls(CollapsableTable cTable)
        {
            cTable.panel.Parent = panel;
            //panel.SetColumn(cTable.panel, 1);
            panel.Controls.Add(cTable.panel);
        }
    }
}
