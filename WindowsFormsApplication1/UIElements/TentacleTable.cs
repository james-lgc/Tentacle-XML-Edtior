using System;
using TentacleXMLEditor.Colours;
using TentacleXMLEditor.Interfaces;
using TentacleXMLEditor.Processors;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentacleXMLEditor.UIElements
{
    public class TentacleTable : TableLayoutPanel, IColourable
    {
        public TwoToneColour TTColour { get; set; }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetColours();
            TableSizer.AutoSize(this);
        }

        public TentacleTable(Control parent, int rowCount, int columnCount, DockStyle dockStyle)
        {
            Parenter.Parent(this, parent);
            Dock = dockStyle;
            ColumnCount = columnCount;
            RowCount = rowCount;
        }

        public void SetColours()
        {
            TTColour = ColourManager.CurrentTheme.DarkBackGround;
            Colourizer.Colourize(this, TTColour);
        }
    }
}
