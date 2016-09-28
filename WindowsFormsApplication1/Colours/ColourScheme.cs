using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentacleXMLEditor
{
    public struct ColourScheme
    {
        public TwoToneColour DarkBackGround { get; }
        public TwoToneColour LightBackGround { get; }

        public TwoToneColour TextBox { get; }

        public TwoToneColour AddButton { get; }
        public TwoToneColour ExpandButton { get; }
        public TwoToneColour RemoveButton { get; }
        public TwoToneColour MoveButton { get; }

        public ColourScheme(TwoToneColour[] backGrounds, TwoToneColour textBox, TwoToneColour[] buttons)
        {
            DarkBackGround = backGrounds[0];
            LightBackGround = backGrounds[1];

            TextBox = textBox;

            AddButton = buttons[0];
            ExpandButton = buttons[1];
            RemoveButton = buttons[2];
            MoveButton = buttons[3];
        }
        
    }
}
