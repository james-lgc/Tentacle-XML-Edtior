using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class DialogueBox : UIBox<Line>
    {
        TableLayoutPanel panel;
        SplitBox splitBox;
        RepliesTable repliesTable;


        public void SetUp()
        {
            panel = new TableLayoutPanel();
            panel.RowCount = 2;
            panel.ColumnCount = 1;
            //splitBox = new SplitBox();
            //splitBox.SetUp(panel, 0);
            repliesTable = new RepliesTable();
        }

    }
}
