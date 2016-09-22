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
        public override string BoxLabel{ get { return "Conversations"; } }
        public override int Fields { get { return 1; } }
        public override string[] LabelTexts { get { return new string[] { "Name" }; } }
        public override bool IsCollapsable { get { return true; } }
        public override int[] NumFields { get { return null; } }
        public override int ColumnCount { get { return 1; } }
        public override string ExtraText { get { return "Conversation"; } }

        //private StoryStageTable Table { get; set; }

        public CharacterBox(Conversation sentX, UITable<Conversation> parentTable, int rowNum)
        {
            base.SetUp<StoryStageTable>(sentX, parentTable, rowNum);
            /*base.SetUp(ThisX, form, characterTable, rowNum, "", 1, "StoryStage");

            //StoryStageTable table = new StoryStageTable(form, this, ThisX.storyStages);
            //table.SetUp(form, characterBox.GroupBox1, storyStages.Length, 1, storyStages, "StoryStage");
            //ChildTable.panel.Top = 120;
            AssignTable(table);
            BoxHeading.InputControls[0].DataBindings.Add("Text", ThisX, "name", false, DataSourceUpdateMode.OnPropertyChanged);*/
            //return;
        }

        /*public override Conversation ReturnX()
        {
            StoryStage[] storyStages = ChildTable.ReturnContents;
            ThisX.storyStages = storyStages;
            return base.ReturnX();
        }*/
    }
}
