using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class TentacleButton : Button
    {
        //public virtual string Text { get; set; }
        protected Color baseColour;
        protected Color textColour;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            AutoSize = true;
        }

        public TentacleButton(Control control, string text, Color[] colours)
        {
            Text = text;
            BackColor = colours[0];
            ForeColor = colours[1];
            Parent = control;
            control.Controls.Add(this);
        }

        public TentacleButton(CollapsableTable cTable, string text, Color[] colours)
        {
            Text = text;
            BackColor = colours[0];
            ForeColor = colours[1];
            Parent = cTable.panel;
            cTable.panel.SetRow(this, cTable.panel.RowCount - 1);
            cTable.panel.SetColumn(this, 0);
            cTable.panel.Controls.Add(this);
        }
    }
}
