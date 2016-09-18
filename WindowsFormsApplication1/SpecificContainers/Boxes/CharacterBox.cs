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
        public HeadedEditableContainer container;
        StoryStageTable storyStageTable;

        public CharacterBox(Form1 form, CharacterTable characterTable, int rowNum, Conversation conversation)
        {
           // base.SetUp(form, characterTable.cTable, rowNum, conversation.name);
            container = new HeadedEditableContainer(form, characterTable.cTable.panel, rowNum, "Name",conversation.name, 0);
            //container = new HeadedEditableContainer(form, characterTable.table.panel, rowNum, conversation.name);
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = conversation.name;
            container.splitBox.textBox.DataBindings.Add("Text", conversation, "name", false, DataSourceUpdateMode.OnPropertyChanged);
            storyStageTable = new StoryStageTable(form, this, conversation.storyStages);
            container.panel.AutoScroll = true;
            TableSizer.AutoSize(container.panel);
        }


    }
}
