using System;
using System.Windows.Forms;


namespace TentacleXMLEditor.Colours
{
    public class Colourizer
    {
        public static void Colourize(Control control, TwoToneColour ttColour)
        {
            control.BackColor = ttColour.Colours[0];
            control.ForeColor = ttColour.Colours[1];
        }
    }
}
