using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
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
            //parentPanel.SetCellPosition(control, new TableLayoutPanelCellPosition(rowNum, columnNum));
            parentPanel.Controls.Add(control);
        }

        static public void Parent(Control control, TentacleDoc tDoc)
        {
            control.Parent = tDoc;
            control.Dock = DockStyle.Fill;
            tDoc.Controls.Add(control);
        }
    }
}
