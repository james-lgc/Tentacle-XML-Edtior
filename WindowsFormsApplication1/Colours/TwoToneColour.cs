using System;
using System.Drawing;

namespace TentacleXMLEditor.Colours
{
    public class TwoToneColour
    {
        private Color BaseColour { get; set; }
        private Color TextColour { get; set; }
        public Color[] Colours { get { return new Color[]{ BaseColour, TextColour}; } }

        public TwoToneColour(Color baseColour, Color textColour)
        {
            BaseColour = baseColour;
            TextColour = textColour;
        }
    }
}
