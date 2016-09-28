using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentacleXMLEditor
{
    public class CoControl : Control
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.BackColor = System.Drawing.Color.DarkGray;
        }
    }
}
