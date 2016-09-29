using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentacleXMLEditor
{
    class TentacleMenuStrip : MenuStrip
    {
        public TentacleMenuStrip(TentacleDoc tDoc)
        {
            Dock = DockStyle.Top;
            SendToBack();
            tDoc.Controls.Add(this);

            ToolStripMenuItem fileMenu = new ToolStripMenuItem();
            fileMenu.Text = "File";

            ToolStripMenuItem newButton = new ToolStripMenuItem();
            newButton.Text = "New";
            ToolStripMenuItem saveButton = new ToolStripMenuItem();
            saveButton.Text = "Save";
            ToolStripMenuItem loadButton = new ToolStripMenuItem();
            loadButton.Text = "Load";


            Items.Add(fileMenu);

            fileMenu.DropDownItems.Add(newButton);
            fileMenu.DropDownItems.Add(saveButton);
            fileMenu.DropDownItems.Add(loadButton);

            newButton.Click += tDoc.CreateNew;
            saveButton.Click += tDoc.SaveFile;
            loadButton.Click += tDoc.BypassLoad;
        }
    }
}
