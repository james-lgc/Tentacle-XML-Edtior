using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class CharacterTable : UITable<Conversation<StoryStage<ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>>>>
    {
        //public GroupBox groupBox;
        public CharacterTable(GroupBox groupBox, int rowCount, int columnCount, Conversation<StoryStage<ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>>>[] conversations, string extraText) : base(groupBox, rowCount, columnCount, conversations, extraText)
        {
            //labelTexts = new string [] { "Name" };
            labelTexts = null;
            //base.SetUp(form, mainDisplay.container.groupBox, conversations.Length, 1, conversations, "Conversation");
            for (int i = 0; i < xArray.Length; i++)
            {
                //CharacterBox characterBox = new CharacterBox(form, this, i, xArray[i]);
                //base.AddBox(characterBox);
            }
            cTable.panel.AutoScroll = true;
        }

        /*public override void AddRow(Object sender, EventArgs e)
        {
            base.AddRow(sender, e);
            //move label adding to UITable
            //TentacleLabel tLabel = new TentacleLabel("Name", cTable.panel.RowCount - 2, cTable.panel);
            //base.AddLabelWithText("Name");
            NewX = new Conversation();
            NewX.Build();
            CharacterBox characterBox = new CharacterBox(form1, this, cTable.panel.RowCount - 1, NewX);
            base.AddBox(characterBox);
        }*/
    }
}
