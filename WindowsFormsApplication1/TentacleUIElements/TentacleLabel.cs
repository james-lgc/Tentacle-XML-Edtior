using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentacleXMLEditor
{
    public class TentacleLabel : Label, IColourable
    {
        public TwoToneColour TTColour { get; set; }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }

        public TentacleLabel (string labelText, int i, TableLayoutPanel panel) : base()
        {
            Text = labelText;
            SetColours();
            Parenter.Parent(this, panel, i, panel.ColumnCount - 2);
        }

        public TentacleLabel (string labelText, Control control) : base()
        {
            Text = labelText;
            Parenter.Parent(this, control);
        }

        public void SetColours()
        {
            TTColour = ColourManager.CurrentTheme.DarkBackGround;
            Colourizer.Colourize(this, TTColour);
        }
    }
}
