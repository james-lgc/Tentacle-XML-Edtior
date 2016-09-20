using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class TentacleButton : Button
    {
        protected Color baseColour;
        protected Color textColour;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            AutoSize = true;
            ForeColor = textColour;
            BackColor = baseColour;
        }
    }
}
