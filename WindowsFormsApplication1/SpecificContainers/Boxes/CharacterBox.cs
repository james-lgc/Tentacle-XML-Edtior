using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class CharacterBox : UIBox<Conversation<StoryStage<ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>>>, StoryStage<ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>>>
    {
        public override int Fields { get { return 1; } }
        public override string[] LabelTexts { get { return new string[] { "Name" }; } }
        public override bool IsCollapsable { get { return true; } }
        public override int[] NumFields { get { return null; } }

        //private StoryStageTable Table { get; set; }

        public CharacterBox(Conversation<StoryStage<ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>>> sentX, TentacleDoc form, UITable<Conversation<StoryStage<ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>>>> parentTable, int rowNum, string labelText, int columnCount, string extraText) : base(sentX, form, parentTable, rowNum, labelText, columnCount, extraText)
        {

            /*"base.SetUp(ThisX, form, characterTable, rowNum, "", 1, "StoryStage");

            //StoryStageTable table = new StoryStageTable(form, this, ThisX.storyStages);
            //table.SetUp(form, characterBox.GroupBox1, storyStages.Length, 1, storyStages, "StoryStage");
            //ChildTable.panel.Top = 120;
            AssignTable(table);
            BoxHeading.InputControls[0].DataBindings.Add("Text", ThisX, "name", false, DataSourceUpdateMode.OnPropertyChanged);*/
            return;
        }

        /*public override Conversation ReturnX()
        {
            StoryStage[] storyStages = ChildTable.ReturnContents;
            ThisX.storyStages = storyStages;
            return base.ReturnX();
        }*/
    }
}
