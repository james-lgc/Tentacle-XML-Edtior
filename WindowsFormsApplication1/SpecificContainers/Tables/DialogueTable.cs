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

        public DialogueTable(Form1 form, StoryStageBox storyStageBox, ConversationStage[] conversationStages)
        {
            base.SetUp(form, this, storyStageBox.container, conversationStages.Length, 1, 1, conversationStages, null, "Dialogue");

            for (int i = 0; i < xArray.Length; i++)
            {
                DialogueBox dialogueBox = new DialogueBox(form, this, i, conversationStages[i]);
                form.loadingPanel.IncreaseProgress();
            }
            base.Expand();
        }

        public override void AddRow(object sender, EventArgs e)
        {
            base.AddRow(sender, e);
            newX = new ConversationStage();
            newX.Build();
            DialogueBox dialogueBox = new DialogueBox(form1, this, cTable.panel.RowCount -2, newX);
        }
    }
}
