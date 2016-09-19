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

        public DialogueBox(Form1 form, DialogueTable dialogueTable, int rowNum, ConversationStage conversationStage)
        {
            dTable = dialogueTable;
            container = new HeadedFixedContainer(form, dialogueTable.cTable.panel, rowNum, "Dialogue");
            string[] labelTexts = new string[] { "" };

            lineTable = new LineTable(form, this, conversationStage.lines);
            container.AddHeading(form, lineTable.cTable, 0, labelTexts, true);

        }

    }
}
