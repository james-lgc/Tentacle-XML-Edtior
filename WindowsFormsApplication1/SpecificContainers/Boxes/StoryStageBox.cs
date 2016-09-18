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
        TextBox storyThreadBox;
        NumericUpDown stageNumBox;
        Label storyThreadLabel;
        Label stageNumLabel;
        //public HeadedFixedContainer dialogueContainer;
        public DialogueTable dialogueTable;
        

        public StoryStageBox(Form1 form, StoryStageTable storyStageTable, int rowNum, StoryStage storyStage)
        {
            container = new HeadedFixedContainer(form, storyStageTable.cTable.panel, rowNum, storyStage.id.ToString());
            subTable = new CollapsableTable(form, container, 3, 2, 0);
            //storyThreadBox = new SplitBox(form, subTable.panel, 0, "StoryThread",  storyStage.storyThread, 0);

            storyThreadLabel = new Label();
            storyThreadLabel.Parent = subTable.panel;
            storyThreadLabel.Text = "StoryThread";
            subTable.panel.SetRow(storyThreadLabel, 0);

            subTable.panel.Controls.Add(storyThreadLabel);

            storyThreadBox = new TextBox();
            storyThreadBox.Parent = subTable.panel;
            subTable.panel.SetCellPosition(storyThreadBox, new TableLayoutPanelCellPosition(0, 1));
            storyThreadBox.DataBindings.Add("Text", storyStage, "storyThread", false, DataSourceUpdateMode.OnPropertyChanged);
            subTable.panel.Controls.Add(storyThreadBox);
            subTable.panel.Controls.Add(storyThreadBox);

            stageNumBox = new NumericUpDown();
            stageNumBox.Parent = subTable.panel;
            subTable.panel.SetCellPosition(stageNumBox, new TableLayoutPanelCellPosition(1, 1));
            //stageNumBox.DataBindings.Add("Number", storyStage, "stageNumber", false, DataSourceUpdateMode.OnPropertyChanged);
            subTable.panel.Controls.Add(stageNumBox);

            stageNumLabel = new Label();
            stageNumLabel.Parent = subTable.panel;
            stageNumLabel.Text = "StageNumber";
            subTable.panel.SetCellPosition(stageNumLabel, new TableLayoutPanelCellPosition(1, 0));
            subTable.panel.Controls.Add(stageNumLabel);

            //dialogueContainer = new HeadedFixedContainer(form, subTable.panel, 2, "Dialogues");
            dialogueTable = new DialogueTable(form, this, storyStage.conversationStages);
            //container.panel.AutoScroll = true;
            TableSizer.AutoSize(subTable.panel);
            //TableSizer.AutoSize(dialogueContainer.panel);
            //TableSizer.AutoSize(container.panel);
        }
    }
}
