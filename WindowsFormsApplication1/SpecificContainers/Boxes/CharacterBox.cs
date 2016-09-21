using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class CharacterBox : UIBox<Conversation, StoryStage>
    {
        public override int Fields { get { return 1; } }
        public override string[] LabelTexts { get { return new string[] { "Name" }; } }
        public override bool IsCollapsable { get { return true; } }
        public override int[] NumFields { get { return null; } }

        //private StoryStageTable Table { get; set; }

        public CharacterBox(TentacleDoc form, CharacterTable characterTable, int rowNum, Conversation conversation)
        {
            base.SetUp(conversation, form, characterTable, rowNum, "");
            StoryStageTable table = new StoryStageTable(form, this, ThisX.storyStages);
            //ChildTable.panel.Top = 120;
            AssignTable(table);
            BoxHeading.InputControls[0].DataBindings.Add("Text", ThisX, "name", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public override Conversation ReturnX()
        {
            StoryStage[] storyStages = ChildTable.ReturnContents;
            ThisX.storyStages = storyStages;
            return base.ReturnX();
        }
    }
}
