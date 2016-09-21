using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class StoryStageBox : UIBox<StoryStage, ConversationStage>
    {
        public override int Fields { get { return 2; } }
        public override string[] LabelTexts { get { return new string[] { "StoryThread", "StageNumber" }; } }
        public override bool IsCollapsable { get { return true; } }
        public override int[] NumFields { get { return new int[] { 1 }; } }

        //public CollapsableTable subTable;
        //public DialogueTable dialogueTable;
        

        public StoryStageBox(TentacleDoc form, StoryStageTable storyStageTable, int rowNum, StoryStage storyStage)
        {
            base.SetUp(storyStage, form, storyStageTable, rowNum, storyStage.id.ToString());
            DialogueTable table = new DialogueTable(form, this, storyStage.conversationStages);
            //ChildCTable = dialogueTable.cTable;
            //dialogueTable.cTable.panel.Top = 500;

            base.AssignTable(table);
            BoxHeading.InputControls[0].DataBindings.Add("Text", ThisX, "storyThread", false, DataSourceUpdateMode.OnPropertyChanged);
            //BoxHeading.BindData("Value", storyStage, "stageNumber");
            BoxHeading.InputControls[1].DataBindings.Add("Value", ThisX, "stageNumber", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public override StoryStage ReturnX()
        {
            ConversationStage[] cStages = ChildTable.ReturnContents;
            ThisX.conversationStages = cStages;
            return base.ReturnX();
        }
    }
}
