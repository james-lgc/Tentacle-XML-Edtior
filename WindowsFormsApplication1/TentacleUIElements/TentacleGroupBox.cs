using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class TentacleGroupBox : GroupBox
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            BackColor = ColourManager.backGroundColour2;
            ForeColor = ColourManager.textColour;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Dock = DockStyle.Fill;
        }

        public TentacleGroupBox(string labelText)
        {
            Text = labelText;
        }
    }
}
