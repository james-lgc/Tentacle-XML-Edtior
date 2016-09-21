using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class CharacterBox : UIBox<Conversation>
    {
        //public HeadedEditableContainer container;
        //public HeadedFixedContainer container;
        StoryStageTable storyStageTable;
        public Button button;

        public CharacterBox(TentacleDoc form, CharacterTable characterTable, int rowNum, Conversation conversation)
        {
            base.SetUp(conversation, form, characterTable.cTable.panel, rowNum, "");
            //container = new HeadedFixedContainer(form, characterTable.cTable.panel, rowNum, "");
            //container.groupBox.Padding = new Padding(20);
            string[] labelTexts = new string[] { "Name" };


            storyStageTable = new StoryStageTable(form, this, conversation.storyStages);;
            storyStageTable.cTable.panel.Top = 120;
            base.AddHeading(form, storyStageTable.cTable, 1, labelTexts, true);
            //container.AddHeading(form, storyStageTable.cTable, 1, labelTexts, true);
            TextBoxes[0].DataBindings.Add("Text", conversation, "name", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public override Conversation ReturnX()
        {
            StoryStage[] storyStages = storyStageTable.ReturnContents;
            thisX.storyStages = storyStages;
            return base.ReturnX();
        }
    }
}
