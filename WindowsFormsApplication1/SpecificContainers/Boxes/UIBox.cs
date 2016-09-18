using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public abstract class UIBox<X>
    {
        int caseSwitch;

        protected void SetUp(Form1 form, CollapsableTable cTable, int rowNum, string name)
        {
            switch (caseSwitch)
            {
                case 0:
                    //build conversation boxes
                    //HeadedEditableContainer container = new HeadedEditableContainer(form, cTable.panel, rowNum, name, textBoxtext);
                    break;
                case 1:
                    //build storystageboxes
                    break;
                case 2:
                    //build dialogue boxes
                    break;
                case 3:
                    //build reply boxes
                    break;



            }
            //container = new HeadedEditableContainer(form, characterTable.table.panel, rowNum, conversation.name);
            //storyStageTable = new StoryStageTable(form, this, conversation);
        }

        public void Expand()
        {

        }
        
    }
}
