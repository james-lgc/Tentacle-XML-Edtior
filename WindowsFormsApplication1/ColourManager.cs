using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public struct ColourManager
    {
        //public static Color backGroundColour = Color.FromArgb(15, 17, 18);
        public static Color backGroundColour = Color.FromArgb(54, 54, 54);
        public static Color backGroundColour2 = Color.FromArgb(79, 79, 79);
        //public static Color textColour = Color.LightBlue;
        public static Color textColour = Color.WhiteSmoke;

        public static Color addButtonBaseColour = Color.FromArgb(191, 245, 195);
        public static Color addButtonTextColour = backGroundColour;

        public static Color expandButtonBaseColour = Color.FromArgb(191, 214, 245);
        public static Color expandButtonTextColour = backGroundColour;

        public static Color removeButtonBaseColour = Color.FromArgb(245, 191, 241);
        public static Color removeButtonTextColour = backGroundColour;

        public static Color moveButtonBaseColour = Color.FromArgb(245, 222, 191);
        public static Color moveButtonTextColour = backGroundColour;

        public static Color[] addButtonColours = { addButtonBaseColour, addButtonTextColour };
        public static Color[] expandButtonColours = { expandButtonBaseColour, expandButtonTextColour };
        public static Color[] removeButtonColours = { removeButtonBaseColour, removeButtonTextColour };
        public static Color[] moveButtonColours = { moveButtonBaseColour, moveButtonTextColour };
    }
}
