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
        public HeadedFixedContainer container;
        StoryStageTable storyStageTable;
        public Button button;
        bool isExpanded;

        public CharacterBox(Form1 form, CharacterTable characterTable, int rowNum, Conversation conversation)
        {
            base.SetUp(form, characterTable.cTable, rowNum, 1, conversation.name);
            //container = new HeadedEditableContainer(form, characterTable.cTable.panel, rowNum, "Name",conversation.name, 0);
            container = new HeadedFixedContainer(form, characterTable.cTable.panel, rowNum, "");
            container.groupBox.Padding = new Padding(20);
            string[] labelTexts = new string[] { "Name" };
            
            //CollapsableTable subTable = new CollapsableTable(form, container, 1, 3, 0);
            //subTable.panel.Dock = DockStyle.None;


            storyStageTable = new StoryStageTable(form, this, conversation.storyStages);;
            storyStageTable.cTable.panel.Top = 120;
            container.AddHeading(form, storyStageTable.cTable, 1, labelTexts);
            container.textBoxes[0].DataBindings.Add("Text", conversation, "name", false, DataSourceUpdateMode.OnPropertyChanged);

            isExpanded = false;
            storyStageTable.cTable.panel.Visible = false;
        }

    }
}
