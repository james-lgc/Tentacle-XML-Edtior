using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class MainDisplay : UIBox<ConversationList<Conversation<StoryStage<ConversationStage<Line<Reply<string>>>>>>, Conversation<StoryStage<ConversationStage<Line<Reply<string>>>>>>
    {
        public HeadedFixedContainer container;
        public CharacterTable characterTable;

        public MainDisplay(TentacleDoc form, ConversationList<Conversation<StoryStage<ConversationStage<Line<Reply<string>>>>>> cList)
        {
            base.SetUp(cList, form, null, 0, "Conversations", 1, "Conversation");
            container = new HeadedFixedContainer(form, null, 0, "Conversations");
            container.groupBox.BringToFront();
            container.groupBox.SuspendLayout();
            container.groupBox.Hide();
            form.loadingPanel = new LoadingPanel(form, cList);
            //characterTable = new CharacterTable(form, this, cList.conversations);
            container.groupBox.ResumeLayout();
            container.groupBox.Show();
            form.Controls.Remove(form.loadingPanel.fullAppPanel);
            form.loadingPanel = null;
        }
    }
}
