using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentacleXMLEditor
{
    public class CollapsableTable : IColourable
    {
        public TwoToneColour TTColour { get; set; }

        public TableLayoutPanel panel;

        public CollapsableTable(Control parent, int rowCount, int columnCount, DockStyle dockStyle)
        {
            panel = new TableLayoutPanel();
            SetColours();
            Parenter.Parent(panel, parent);
            panel.Dock = dockStyle;
            panel.ColumnCount = columnCount;
            panel.RowCount = rowCount;
            TableSizer.AutoSize(panel);
        }

        public void SetColours()
        {
            TTColour = ColourManager.CurrentTheme.DarkBackGround;
            Colourizer.Colourize(panel, TTColour);
        }
    }
}
