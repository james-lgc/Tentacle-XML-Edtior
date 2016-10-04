using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentacleXMLEditor.Colours
{
    public class ColourManager
    {
        public static ColourScheme CurrentTheme;

        private static Color textColour;
        private static Color darkBase;
        private static TwoToneColour darkBG;
        private static TwoToneColour lightBG;
        private static TwoToneColour[] backGrounds;

        private static TwoToneColour textBox;

        private static TwoToneColour add;
        private static TwoToneColour expand;
        private static TwoToneColour remove;
        private static TwoToneColour move;
        private static TwoToneColour[] buttons;

        public static void SetNightTheme()
        {
            textColour = Color.WhiteSmoke;
            darkBase = Color.FromArgb(54, 54, 54);
            darkBG = new TwoToneColour(darkBase, textColour);
            lightBG = new TwoToneColour(Color.FromArgb(79, 79, 79), textColour);
            backGrounds = new TwoToneColour[] { darkBG, lightBG };

            textBox = new TwoToneColour(textColour, darkBase);

            add = new TwoToneColour(Color.FromArgb(191, 245, 195), darkBase);
            expand = new TwoToneColour(Color.FromArgb(191, 214, 245), darkBase);
            remove = new TwoToneColour(Color.FromArgb(245, 191, 241), darkBase);
            move = new TwoToneColour(Color.FromArgb(245, 222, 191), darkBase);
            buttons = new TwoToneColour[] { add, expand, remove, move };

            CurrentTheme = new ColourScheme(backGrounds, textBox, buttons);
        }
    }
}
