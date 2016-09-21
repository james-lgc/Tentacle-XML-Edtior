using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class DialogueBox : UIBox<ConversationStage, Line>
    {
        public override int Fields { get { return 1; } }
        public override string[] LabelTexts { get { return new string[] { "Dialogue Id" }; } }
        public override bool IsCollapsable { get { return true; } }
        public override int[] NumFields { get { return new int[] { 0 }; } }

        //public HeadedFixedContainer container;
        //private LineTable Table;

        public DialogueBox(TentacleDoc form, DialogueTable dialogueTable, int rowNum, ConversationStage conversationStage)
        {
            base.SetUp(conversationStage, form, dialogueTable, rowNum, "Dialogue");
            LineTable table = new LineTable(form, this, ThisX.lines);
            base.AssignTable(table);
            BoxHeading.InputControls[0].DataBindings.Add("Value", ThisX, "id", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public override ConversationStage ReturnX()
        {
            Line[] lines = ChildTable.ReturnContents;
            ThisX.lines = lines;
            return base.ReturnX();
        }
    }
}
