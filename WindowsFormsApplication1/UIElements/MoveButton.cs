using System;
using TentacleXMLEditor.Colours;
using TentacleXMLEditor.Interfaces;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TentacleXMLEditor.UIElements
{
    public class MoveButton : TentacleButton
    {
        public ContextMenuStrip Menu1 { get; private set; }
        public ToolStripMenuItem UpButton { get; private set; }
        public ToolStripMenuItem DownButton { get; private set; }

        public MoveButton(Control control, string text = null) : base(control, text)
        {
            Menu1 = new ContextMenuStrip();
            UpButton = new ToolStripMenuItem("Up");
            Menu1.Items.Add(UpButton);
            DownButton = new ToolStripMenuItem("Down");
            Menu1.Items.Add(DownButton);
            Click += new EventHandler(ShowMenu);
        }

        private void ShowMenu(Object sender, EventArgs e)
        {
            Menu1.Show(this.PointToScreen(new Point(0, Height)));
        }
    }
}
