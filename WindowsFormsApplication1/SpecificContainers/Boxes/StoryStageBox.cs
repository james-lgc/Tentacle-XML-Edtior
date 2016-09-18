using System;
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
        HeadedFixedContainer container;
        public CollapsableTable subTable;
        //SplitBox storyThreadBox;
        //SplitBox stageNumBox;
        public HeadedFixedContainer dialogueContainer;
        public DialogueTable dialogueTable;
        

        public StoryStageBox(Form1 form, StoryStageTable storyStageTable, int rowNum, StoryStage storyStage)
        {
            container = new HeadedFixedContainer(form, storyStageTable.cTable.panel, rowNum, storyStage.id.ToString());
            subTable = new CollapsableTable(form, container, 3, 1, 1);
            //storyThreadBox = new SplitBox(form, subTable.panel, 0, "StoryThread",  storyStage.storyThread, 0);
            //storyThreadBox.textBox.DataBindings.Add("Text", storyStage, "storyThread", false, DataSourceUpdateMode.OnPropertyChanged);
            //stageNumBox = new SplitBox(form, subTable.panel, 1, "Stage Number: ", null, storyStage.stageNumber);
            //stageNumBox.numUpDown.DataBindings.Add("Number", storyStage, "stageNumber", false, DataSourceUpdateMode.OnPropertyChanged);
            dialogueContainer = new HeadedFixedContainer(form, subTable.panel, 2, "Dialogues");
            dialogueTable = new DialogueTable(form, this, storyStage.conversationStages);
            //container.panel.AutoScroll = true;
            TableSizer.AutoSize(subTable.panel);
            //TableSizer.AutoSize(dialogueContainer.panel);
            //TableSizer.AutoSize(container.panel);
        }
    }
}
