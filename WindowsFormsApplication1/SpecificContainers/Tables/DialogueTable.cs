using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class DialogueTable : UITable<ConversationStage>
    {
        //HeadedFixedContainer container;

        public DialogueTable(Form1 form, StoryStageBox storyStageBox, ConversationStage[] conversationStages)
        {
            base.SetUp(form, storyStageBox.dialogueContainer, conversationStages.Length, 1, conversationStages);
            for (int i = 0; i < xArray.Length; i++)
            {
                DialogueBox dialogueBox = new DialogueBox(form, this, i, conversationStages[i]);
            }
            base.Expand();
            //cTable.panel.AutoScroll = true;
        }
    }
}
