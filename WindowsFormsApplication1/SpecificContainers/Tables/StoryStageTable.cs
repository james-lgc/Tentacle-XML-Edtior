using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class StoryStageTable : UITable<StoryStage>
    {
        public StoryStageTable(Form1 form, CharacterBox characterBox, StoryStage[] storyStages)
        {
            base.SetUp(form, this, characterBox.container, storyStages.Length, 1, 1, storyStages, null, "StoryStage");
            for (int i = 0; i < storyStages.Length; i++)
            {
                StoryStageBox storyStageBox = new StoryStageBox(form, this, i, storyStages[i]);
                boxes.Add(storyStageBox);
                form.loadingPanel.IncreaseProgress();
            }
            base.Expand();
        }

        public override void AddRow(object sender, EventArgs e)
        {
            base.AddRow(sender, e);
            newX = new StoryStage();
            newX.Build();
            StoryStageBox storyStageBox = new StoryStageBox(form1, this, cTable.panel.RowCount - 2, newX);
            boxes.Add(storyStageBox);
        }
    }
}
