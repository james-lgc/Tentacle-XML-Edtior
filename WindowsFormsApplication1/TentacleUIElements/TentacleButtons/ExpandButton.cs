using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class ExpandButton : TentacleButton
    {
        //public override string Text { get; set; }

        protected override void OnCreateControl()
        {
            baseColour = ColourManager.expandButtonBaseColour;
            textColour = ColourManager.expandButtonTextColour;
            base.OnCreateControl();
        }

        public ExpandButton(CollapsableTable cTable, int i)
        {
            Text = "Expand";
            ForeColor = ColourManager.backGroundColour;
            BackColor = ColourManager.textColour;
            Parent = cTable.panel;
            cTable.panel.SetRow(this, i);
            cTable.panel.SetColumn(this, 0);
            cTable.panel.Controls.Add(this);
        }
    }
}
