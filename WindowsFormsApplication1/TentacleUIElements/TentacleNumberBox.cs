using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class TentacleNumberBox : NumericUpDown
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ForeColor = ColourManager.backGroundColour;
            BackColor = ColourManager.textColour;
            Dock = DockStyle.Top;
        }

        public TentacleNumberBox(int i, TableLayoutPanel panel) : base()
        {
            panel.SetRow(this, i);
            panel.SetColumn(this, panel.ColumnCount - 1);
            panel.Controls.Add(this);
        }

    }
}
