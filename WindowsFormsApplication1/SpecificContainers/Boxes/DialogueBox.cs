using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class DialogueBox : UIBox<ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>, Line<Reply<WrappedReply<ReplyString<string>>>>>
    {
        public override int Fields { get { return 1; } }
        public override string[] LabelTexts { get { return new string[] { "Dialogue Id" }; } }
        public override bool IsCollapsable { get { return true; } }
        public override int[] NumFields { get { return new int[] { 0 }; } }

        //public HeadedFixedContainer container;
        //private LineTable Table;

        public DialogueBox(ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>> sentX, TentacleDoc form, DialogueTable parentTable, int rowNum, string labelText, int columnCount, string extraText) : base(sentX, form, parentTable, rowNum, labelText, columnCount, extraText)
        {
            //base.SetUp(conversationStage, form, dialogueTable, rowNum, "Dialogue");
            //LineTable table = new LineTable(form, this, ThisX.lines);
            //base.AssignTable(table);
            //BoxHeading.InputControls[0].DataBindings.Add("Value", ThisX, "id", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        /*public override ConversationStage<Line<Reply<string>>> ReturnX()
        {
            Line[] lines = ChildTable.ReturnContents;
            ThisX.lines = lines;
            return base.ReturnX();
        }*/
    }
}
