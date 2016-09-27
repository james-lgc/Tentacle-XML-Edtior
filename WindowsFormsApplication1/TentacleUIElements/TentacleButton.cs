using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class TentacleButton : Button, IColourable
    {
        public TwoToneColour TTColour { get; set; }
        protected Color baseColour;
        protected Color textColour;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            AutoSize = true;
        }

        public TentacleButton(Control control, string text)
        {
            SetUp(text);
            DetermineColour(text);
            SetColours();
            Parenter.Parent(this, control);
        }

        public TentacleButton(CollapsableTable cTable, string text)
        {
            SetUp(text);
            DetermineColour(text);
            SetColours();
            Parenter.Parent(this, cTable.panel, cTable.panel.RowCount - 1, 0);
        }
        private void SetUp(string text)
        {
            Text = text;
        }

        private void DetermineColour(string text)
        {
            switch (text)
            {
                case "Expand":
                    TTColour = ColourManager.CurrentTheme.ExpandButton;
                    break;
                case "Remove":
                    TTColour = ColourManager.CurrentTheme.RemoveButton;
                    break;
                case "Move":
                    TTColour = ColourManager.CurrentTheme.MoveButton;
                    break;
                default:
                    TTColour = ColourManager.CurrentTheme.AddButton;
                    break;
            }
        }

        public void SetColours()
        {
            DetermineColour(Text);
            Colourizer.Colourize(this, TTColour);
        }
    }
}
