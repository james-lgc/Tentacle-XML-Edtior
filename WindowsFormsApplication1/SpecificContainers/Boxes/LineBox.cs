using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class LineBox : UIBox<Line>
    {
        //public HeadedFixedContainer container;
        ReplyTable replyTable;
        private TentacleDoc form1;


        public LineBox(TentacleDoc form, LineTable lineTable, int rowNum, Line line)
        {
            Fields = 1;
            LabelTexts = new string[] { "Speech" };
            IsCollapsable = true;
            NumFields = null;

            base.SetUp(line, form, lineTable, rowNum, null);
            //container = new HeadedFixedContainer(form, lineTable.cTable.panel, rowNum, null);
            lineTable.cTable.panel.SetColumn(GroupBox1, 1);
            lineTable.cTable.panel.SetRow(GroupBox1, rowNum);
            string[] labelTexts = new string[] { "Speech" };

            form1 = form;

            replyTable = new ReplyTable(form1, this, line.replies, line);
            ChildCTable = replyTable.cTable;
            //base.AddHeading(form, replyTable.cTable, 1, null, true);
            BoxHeading = new UIBoxHeading<Line>(this);
            BoxHeading.InputControls[0].DataBindings.Add("Text", line, "lineText", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public override Line ReturnX()
        {
            string[] replies = replyTable.ReturnContents;
            thisX.replies = replies;
            return base.ReturnX();
        }

    }
}
