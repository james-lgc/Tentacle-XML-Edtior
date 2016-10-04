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
    public class TentacleNumberBox : NumericUpDown, IColourable
    {
        public TwoToneColour TTColour { get; set; }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Dock = DockStyle.Top;
        }

        public TentacleNumberBox(int i, TableLayoutPanel panel) : base()
        {
            SetColours();
            Parenter.Parent(this, panel, i, panel.ColumnCount - 1);
        }

        public void SetColours()
        {
            TTColour = ColourManager.CurrentTheme.TextBox;
            Colourizer.Colourize(this, TTColour);
        }

    }
}
