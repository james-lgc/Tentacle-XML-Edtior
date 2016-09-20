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
        public DialogueTable dTable;

        public DialogueBox(TentacleDoc form, DialogueTable dialogueTable, int rowNum, ConversationStage conversationStage)
        {
            base.SetUp(conversationStage);
            dTable = dialogueTable;
            container = new HeadedFixedContainer(form, dialogueTable.cTable.panel, rowNum, "Dialogue");
            string[] labelTexts = new string[] { "" };

            lineTable = new LineTable(form, this, conversationStage.lines);
            container.AddHeading(form, lineTable.cTable, 0, labelTexts, true);

        }

        public override ConversationStage ReturnX()
        {
            Line[] lines = lineTable.ReturnContents;
            thisX.lines = lines;
            return base.ReturnX();
        }
    }
}
