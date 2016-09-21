using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class StoryStageTable : UITable<StoryStage<ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>>>
    {
        public StoryStageTable(GroupBox groupBox, int rowCount, int columnCount, ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>[] sentXArray, string extraText) : base(groupBox, rowCount, columnCount, sentXArray, extraText)
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
