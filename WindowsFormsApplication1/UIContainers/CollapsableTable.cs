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

        public CollapsableTable(Control parent, int rowCount, int columnCount, DockStyle dockStyle)
        {
            panel = new TableLayoutPanel();
            panel.Parent = parent;
            parent.Controls.Add(panel);
            panel.Dock = dockStyle;
            panel.BackColor = ColourManager.backGroundColour;
            panel.ColumnCount = columnCount;
            panel.RowCount = rowCount;
            TableSizer.AutoSize(panel);
        }

        public override void SetChildControls(CollapsableTable cTable)
        {
            cTable.panel.Parent = panel;
            panel.Controls.Add(cTable.panel);
        }
    }
}
