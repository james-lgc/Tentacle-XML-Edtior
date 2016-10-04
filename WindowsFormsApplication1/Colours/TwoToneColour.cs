using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
