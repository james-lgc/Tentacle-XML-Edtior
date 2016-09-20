using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class TentacleLabel : Label
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ForeColor = ColourManager.textColour;
            TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }

        public TentacleLabel (string labelText, int i, TableLayoutPanel panel) : base()
        {
            Text = labelText;
            panel.SetRow(this, i);
            panel.SetColumn(this, panel.ColumnCount - 2);
            panel.Controls.Add(this);
        }

        public TentacleLabel (string labelText, GroupBox groupBox) : base()
        {
            Text = labelText;
            Parent = groupBox;
            groupBox.Controls.Add(this);
        }
    }
}
