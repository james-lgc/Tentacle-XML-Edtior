﻿using System;
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

        public DialogueTable(GroupBox groupBox, int rowCount, int columnCount, ConversationStage[] sentXArray, string extraText)
        {
            /*labelTexts = null;
            base.SetUp(form, storyStageBox.GroupBox1, conversationStages.Length, 1, conversationStages, "Dialogue");

            for (int i = 0; i < xArray.Length; i++)
            {
                DialogueBox dialogueBox = new DialogueBox(form, this, i, xArray[i]);
                base.AddBox(dialogueBox);
            }*/
        }

        /*public override void AddRow(object sender, EventArgs e)
        {
            base.AddRow(sender, e);
            NewX = new ConversationStage();
            NewX.Build();
            DialogueBox dialogueBox = new DialogueBox(form1, this, cTable.panel.RowCount -1, NewX);
            boxes.Add(dialogueBox);
        }*/
    }
}
