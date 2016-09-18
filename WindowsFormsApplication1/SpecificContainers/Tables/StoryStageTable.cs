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
            string[] labels = new string[] { "StoryStage" };
            base.SetUp(form, characterBox.container, storyStages.Length, 1, 1, storyStages, labels);
            Console.Write("Table Size: " + cTable.panel.RowCount);
            for (int i = 0; i < storyStages.Length; i++)
            {
                StoryStageBox storyStageBox = new StoryStageBox(form, this, i, storyStages[i]);
            }
            base.Expand();
            //cTable.panel.AutoScroll = true;
        }
    }
}
