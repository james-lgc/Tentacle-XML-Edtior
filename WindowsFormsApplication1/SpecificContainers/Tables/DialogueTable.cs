using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class DialogueTable : UITable<ConversationStage>
    {
        //HeadedFixedContainer container;

        public DialogueTable(TentacleDoc form, StoryStageBox storyStageBox, ConversationStage[] conversationStages)
        {
            labelTexts = null;
            base.SetUp(form, storyStageBox.GroupBox1, conversationStages.Length, 1, conversationStages, "Dialogue");

            for (int i = 0; i < xArray.Length; i++)
            {
                DialogueBox dialogueBox = new DialogueBox(form, this, i, conversationStages[i]);
                base.AddBox(dialogueBox);
            }
        }

        public override void AddRow(object sender, EventArgs e)
        {
            base.AddRow(sender, e);
            newX = new ConversationStage();
            newX.Build();
            DialogueBox dialogueBox = new DialogueBox(form1, this, cTable.panel.RowCount -2, newX);
            boxes.Add(dialogueBox);
        }
    }
}
