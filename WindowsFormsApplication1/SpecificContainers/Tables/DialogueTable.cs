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
            string[] labels = new string[] { "Dialogue" };
            base.SetUp(form, storyStageBox.dialogueContainer, conversationStages.Length, 1, 1, conversationStages, labels);
            for (int i = 0; i < xArray.Length; i++)
            {
                DialogueBox dialogueBox = new DialogueBox(form, this, i, conversationStages[i]);
            }
            base.Expand();
            //cTable.panel.AutoScroll = true;
        }
    }
}
