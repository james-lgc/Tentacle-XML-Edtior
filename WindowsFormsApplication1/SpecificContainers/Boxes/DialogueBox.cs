using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class DialogueBox : UIBox<ConversationStage>
    {
        //public HeadedFixedContainer container;
        public LineTable lineTable;
        public DialogueTable dTable;

        public DialogueBox(TentacleDoc form, DialogueTable dialogueTable, int rowNum, ConversationStage conversationStage)
        {
            Fields = 1;
            LabelTexts = new string[] { "Dialogue Id" };
            IsCollapsable = true;
            NumFields = new int[] { 0 };

            base.SetUp(conversationStage, form, dialogueTable, rowNum, "Dialogue");
            dTable = dialogueTable;
            //container = new HeadedFixedContainer(form, dialogueTable.cTable.panel, rowNum, "Dialogue");
            string[] labelTexts = new string[] { "Dialogue Id" };
            int[] numFields = { 0 };
            lineTable = new LineTable(form, this, thisX.lines);
            ChildCTable = lineTable.cTable;
            //container.AddHeading(form, lineTable.cTable, 1, labelTexts, true, numFields);
            //base.AddHeading(form, lineTable.cTable, 1, labelTexts, true, numFields);
            BoxHeading = new UIBoxHeading<ConversationStage>(this);
            BoxHeading.InputControls[0].DataBindings.Add("Value", thisX, "id", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public override ConversationStage ReturnX()
        {
            Line[] lines = lineTable.ReturnContents;
            thisX.lines = lines;
            return base.ReturnX();
        }
    }
}
