using System;
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
        CollapsableTable subTable;
        SplitBox storyThreadBox;
        SplitBox stageNumBox;
        DialogueTable dialogueTable;

        public StoryStageBox(Form1 form, StoryStageTable storyStageTable, int rowNum, StoryStage storyStage)
        {
            container = new HeadedFixedContainer(form, storyStageTable.cTable.panel, rowNum, storyStage.id.ToString());
            subTable = new CollapsableTable(form, container, 3, 1);
            storyThreadBox = new SplitBox(form, subTable.panel, 0, "StoryThread",  storyStage.storyThread, 0);
            stageNumBox = new SplitBox(form, subTable.panel, 1, "Stage Number: ", num: storyStage.stageNumber);

        }
    }
}
