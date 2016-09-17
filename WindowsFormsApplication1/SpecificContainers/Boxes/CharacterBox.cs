using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class CharacterBox : UIBox<Conversation>
    {
        public HeadedEditableContainer container;
        StoryStageTable storyStageTable;

        public CharacterBox(Form1 form, CharacterTable characterTable, int rowNum, Conversation conversation)
        {
           // base.SetUp(form, characterTable.cTable, rowNum, conversation.name);
            container = new HeadedEditableContainer(form, characterTable.cTable.panel, rowNum, "Name",conversation.name);
            //container = new HeadedEditableContainer(form, characterTable.table.panel, rowNum, conversation.name);
            storyStageTable = new StoryStageTable(form, this, conversation.storyStages);
        }


    }
}
