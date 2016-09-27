using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class TentaclePanel : FlowLayoutPanel
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Margin = Padding.Empty;
            Dock = DockStyle.Left;
        }

        public TentaclePanel(CollapsableTable cTable, int i) : base()
        {
            BackColor = ColourManager.backGroundColour;
            FlowDirection = FlowDirection.LeftToRight;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Parent = cTable.panel;
            cTable.panel.SetRow(this, i);
            cTable.panel.SetColumn(this, 0);
            cTable.panel.Controls.Add(this);
        }

        public TentaclePanel(Control control)
        {
            Parent = control;
            control.Controls.Add(this);
        }
    }
}
