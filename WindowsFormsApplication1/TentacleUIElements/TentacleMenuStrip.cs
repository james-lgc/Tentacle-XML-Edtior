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

            

            ToolStripMenuItem newButton = new ToolStripMenuItem("New");
            ToolStripMenuItem saveAsButton = new ToolStripMenuItem("Save As");
            ToolStripMenuItem saveButton = new ToolStripMenuItem("Save");
            ToolStripMenuItem loadButton = new ToolStripMenuItem("Load");

            ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");
            Items.Add(fileMenu);

            fileMenu.DropDownItems.Add(newButton);
            fileMenu.DropDownItems.Add(saveAsButton);
            fileMenu.DropDownItems.Add(saveButton);
            fileMenu.DropDownItems.Add(loadButton);

            newButton.Click += tDoc.CreateNew;
            saveAsButton.Click += tDoc.SaveAs;
            saveButton.Click += tDoc.Save;
            loadButton.Click += tDoc.BypassLoad;
        }
    }
}
