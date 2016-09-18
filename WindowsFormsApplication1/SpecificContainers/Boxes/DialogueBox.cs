using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class DialogueBox : UIBox<ConversationStage>
    {
        public HeadedFixedContainer container;
        public LineTable lineTable;

        public DialogueBox(Form1 form, DialogueTable dialogueTbale, int rowNum, ConversationStage conversationStage)
        {
            container = new HeadedFixedContainer(form, dialogueTbale.cTable.panel, rowNum, "Lines");
            lineTable = new LineTable(form, this, conversationStage.lines);
            //container.panel.AutoScroll = true;
            //TableSizer.AutoSize(container.panel);
        }

        public void SetUp()
        {
            /*
            panel = new TableLayoutPanel();
            panel.RowCount = 2;
            panel.ColumnCount = 1;
            //splitBox = new SplitBox();
            //splitBox.SetUp(panel, 0);
            repliesTable = new RepliesTable();
            */
        }

    }
}
