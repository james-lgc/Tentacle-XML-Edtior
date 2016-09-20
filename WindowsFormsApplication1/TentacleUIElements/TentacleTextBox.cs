using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class TentacleTextBox : TextBox
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ForeColor = ColourManager.backGroundColour;
            BackColor = ColourManager.textColour;
            Dock = DockStyle.Top;
        }

        public TentacleTextBox(int i, TableLayoutPanel panel) : base()
        {
            Parent = panel;
            ForeColor = ColourManager.backGroundColour;
            BackColor = ColourManager.textColour;
            panel.SetRow(this, i);
            panel.SetColumn(this, panel.ColumnCount - 1);
            panel.Controls.Add(this);
            BringToFront();
        }

        public TentacleTextBox(GroupBox groupBox) : base()
        {
            Parent = groupBox;
            groupBox.Controls.Add(this);
        }
    }
}
