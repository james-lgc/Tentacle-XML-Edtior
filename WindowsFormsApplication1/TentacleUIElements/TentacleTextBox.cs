using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class TentacleTextBox : TextBox, IColourable
    {
        public TwoToneColour TTColour { get; set; }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetColours();
            Dock = DockStyle.Top;
        }

        public TentacleTextBox(int i, TableLayoutPanel panel) : base()
        {
            Parenter.Parent(this, panel, i, panel.ColumnCount - 1);
            BringToFront();
        }

        public TentacleTextBox(GroupBox groupBox) : base()
        {
            Parenter.Parent(this, groupBox);
        }

        public void SetColours()
        {
            TTColour = ColourManager.CurrentTheme.TextBox;
            Colourizer.Colourize(this, TTColour);
        }
    }
}
