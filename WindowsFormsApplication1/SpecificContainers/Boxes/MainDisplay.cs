using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class MainDisplay : UIBox<ConversationList, Conversation>
    {
        //public HeadedFixedContainer container;
        //public CharacterTable characterTable;

        public MainDisplay(ConversationList sentX, TentacleDoc form, UITable<ConversationList> parentTable, int rowNum, string labelText, int columnCount, string extraText) : base(sentX, form, parentTable, rowNum, labelText, columnCount, extraText)
        {
            base.SetUp();
            //ChildTable.BuildBoxes<Conversation, StoryStage<ConversationStage<Line<Reply>>>>()
            //base.SetUp(cList, form, null, 0, "Conversations", 1, "Conversation");
            //container = new HeadedFixedContainer(form, null, 0, "Conversations");
            //container.groupBox.BringToFront();
            //container.groupBox.SuspendLayout();
            //container.groupBox.Hide();
            //form.loadingPanel = new LoadingPanel(form, cList);
            //characterTable = new CharacterTable(form, this, cList.conversations);
            //container.groupBox.ResumeLayout();
            //container.groupBox.Show();
            //form.Controls.Remove(form.loadingPanel.fullAppPanel);
            //form.loadingPanel = null;
        }
    }
}
