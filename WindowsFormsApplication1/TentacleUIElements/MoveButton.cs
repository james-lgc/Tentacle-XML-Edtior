using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentacleXMLEditor
{
    public class MoveButton : TentacleButton
    {
        public ContextMenuStrip Menu1 { get; private set; }
        public ToolStripMenuItem UpButton { get; private set; }
        public ToolStripMenuItem DownButton { get; private set; }

        public MoveButton(Control control, string text = null) : base(control, text)
        {
            Menu1 = new ContextMenuStrip();
            Parenter.Parent(Menu1, this);
            UpButton = new ToolStripMenuItem("Up");
            Menu1.Items.Add(UpButton);
            DownButton = new ToolStripMenuItem("Down");
            Menu1.Items.Add(DownButton);
        }
    }
}
