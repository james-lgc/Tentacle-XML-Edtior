using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class StoryStageTable : UITable<StoryStage>
    {
        public StoryStageTable(TentacleDoc form, CharacterBox characterBox, StoryStage[] storyStages)
        {
            labelTexts = null;
            base.SetUp(form, characterBox.GroupBox1, storyStages.Length, 1, storyStages, "StoryStage");
            for (int i = 0; i < storyStages.Length; i++)
            {
                StoryStageBox storyStageBox = new StoryStageBox(form, this, i, storyStages[i]);
                base.AddBox(storyStageBox);
            }
        }

        public override void AddRow(object sender, EventArgs e)
        {
            base.AddRow(sender, e);
            newX = new StoryStage();
            newX.Build();
            StoryStageBox storyStageBox = new StoryStageBox(form1, this, cTable.panel.RowCount - 1, newX);
            boxes.Add(storyStageBox);
        }
    }
}
