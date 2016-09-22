using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class StoryStageTable : UITable<StoryStage>
    {
        public StoryStageTable(GroupBox groupBox, int rowCount, int columnCount, ConversationStage[] sentXArray, string extraText)
        {
            /*labelTexts = null;
            base.SetUp(form, characterBox.GroupBox1, storyStages.Length, 1, storyStages, "StoryStage");
            for (int i = 0; i < storyStages.Length; i++)
            {
                StoryStageBox storyStageBox = new StoryStageBox(form, this, i, xArray[i]);
                base.AddBox(storyStageBox);
            }*/
        }

        /*public override void AddRow(object sender, EventArgs e)
        {
            base.AddRow(sender, e);
            NewX = new StoryStage();
            NewX.Build();
            StoryStageBox storyStageBox = new StoryStageBox(form1, this, cTable.panel.RowCount - 1, NewX);
            boxes.Add(storyStageBox);
        }*/
    }
}
