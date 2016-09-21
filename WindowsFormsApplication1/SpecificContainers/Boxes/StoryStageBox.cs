﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class StoryStageBox : UIBox<StoryStage>
    {
        //EditableSplitBox numBox;
        //public HeadedFixedContainer container;
        public CollapsableTable subTable;
        public DialogueTable dialogueTable;
        

        public StoryStageBox(TentacleDoc form, StoryStageTable storyStageTable, int rowNum, StoryStage storyStage)
        {
            Fields = 2;
            LabelTexts = new string[] { "StoryThread", "StageNumber" };
            IsCollapsable = true;
            NumFields = new int[] { 1 };

            base.SetUp(storyStage, form, storyStageTable, rowNum, storyStage.id.ToString());
            //container = new HeadedFixedContainer(form, storyStageTable.cTable.panel, rowNum, storyStage.id.ToString());
            dialogueTable = new DialogueTable(form, this, storyStage.conversationStages);
            ChildCTable = dialogueTable.cTable;
            dialogueTable.cTable.panel.Top = 500;
    

            string[] labelTexts = new string[] { "StoryThread", "StageNumber" };
            //container.AddHeading(form, dialogueTable.cTable, 2, labelTexts, true, new int[] { 1 });
            //base.AddHeading(form, dialogueTable.cTable, 2, labelTexts, true, new int[] { 1 });
            BoxHeading = new UIBoxHeading<StoryStage>(this);
            BoxHeading.InputControls[0].DataBindings.Add("Text", storyStage, "storyThread", false, DataSourceUpdateMode.OnPropertyChanged);
            //BoxHeading.BindData("Value", storyStage, "stageNumber");
            BoxHeading.InputControls[1].DataBindings.Add("Value", storyStage, "stageNumber", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public override StoryStage ReturnX()
        {
            ConversationStage[] cStages = dialogueTable.ReturnContents;
            thisX.conversationStages = cStages;
            return base.ReturnX();
        }
    }
}
