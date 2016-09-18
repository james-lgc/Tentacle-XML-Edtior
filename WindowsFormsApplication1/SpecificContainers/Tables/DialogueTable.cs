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

        public DialogueTable(Form1 form, StoryStageBox storyStageBox, ConversationStage[] conversationStages)
        {
            //string[] labels = new string[] { "Dialogue" };
            base.SetUp(form, storyStageBox.subTable, conversationStages.Length, 1, 1, conversationStages, null);
            storyStageBox.subTable.panel.SetColumn(cTable.panel, 1);
            storyStageBox.subTable.panel.SetRow(cTable.panel, 2);
            for (int i = 0; i < xArray.Length; i++)
            {
                DialogueBox dialogueBox = new DialogueBox(form, this, i, conversationStages[i]);
            }
            base.Expand();
            //cTable.panel.AutoScroll = true;
        }
    }
}
