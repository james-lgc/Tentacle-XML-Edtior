using System;
using System.Windows.Forms;

namespace TentacleXMLEditor.Processors
{
    public class Parenter
    {

        static public void Parent(Control control, Control parentControl)
        {
            control.Parent = parentControl;
            parentControl.Controls.Add(control);
        }

        static public void Parent(Control control, TableLayoutPanel parentPanel, int rowNum, int columnNum)
        {
            control.Parent = parentPanel;
            parentPanel.SetRow(control, rowNum);
            parentPanel.SetColumn(control, columnNum);
            parentPanel.Controls.Add(control);
        }

        static public void Parent(Control control, TentacleDoc tDoc)
        {
            control.Parent = tDoc;
            control.Dock = DockStyle.Fill;
            tDoc.Controls.Add(control);
        }

        static public void DeParent(Control control, Control parentControl)
        {
            control.Parent = null;
            parentControl.Controls.Remove(control);
        }

        static public void DeParent(Control control, TentacleDoc tDoc)
        {
            tDoc.Parent = null;
            tDoc.Controls.Remove(control);
        }

        static public void Parent(ToolStripMenuItem item, ContextMenu menu)
        {
            menu.MenuItems.Add(item.Text);
        }
    }
}
