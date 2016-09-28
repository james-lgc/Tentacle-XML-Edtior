using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentacleXMLEditor
{
    public class TentacleGroupBox : GroupBox, IColourable
    {
        public TwoToneColour TTColour { get; set; }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Dock = DockStyle.Fill;
        }

        public TentacleGroupBox(string labelText)
        {
            Text = labelText;
            SetColours();
        }

        public void SetColours()
        {
            TTColour = ColourManager.CurrentTheme.LightBackGround;
            Colourizer.Colourize(this, TTColour);
        }
    }
}
