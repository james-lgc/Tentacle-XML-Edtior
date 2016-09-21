using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class LineBox : UIBox<Line, WrappedReply>
    {
        public override int Fields { get { return 1; } }
        public override string[] LabelTexts { get { return new string[] { "Speech" }; } }
        public override bool IsCollapsable { get { return true; } }
        public override int[] NumFields { get { return null; } }

        //ReplyTable Table { get; set; }

        public LineBox(TentacleDoc form, LineTable lineTable, int rowNum, Line line)
        {

            base.SetUp(line, form, lineTable, rowNum, null);
            ReplyTable table = new ReplyTable(form, this, WrapReplies(line), line);
            base.AssignTable(table);
            ChildTable.cTable.panel.SetColumn(GroupBox1, 1);
            ChildTable.cTable.panel.SetRow(GroupBox1, rowNum);
            BoxHeading.InputControls[0].DataBindings.Add("Text", ThisX, "lineText", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private WrappedReply[] WrapReplies(Line line)
        {
            if (line.replies != null)
            {
                WrappedReply[] wrappedReplies = new WrappedReply[line.replies.Length];
                for (int i = 0; i < wrappedReplies.Length; i++)
                {
                    wrappedReplies[i] = new WrappedReply();
                    wrappedReplies[i].WrappedReply1 = line.replies[i];
                }
                return wrappedReplies;
            }
            else
            {
                WrappedReply[] wrappedReplies = new WrappedReply[0];
                return wrappedReplies;
            }
        }
        public override Line ReturnX()
        {
            WrappedReply[] replies = ChildTable.ReturnContents;
            ThisX.replies = new string[replies.Length];
            for (int i = 0; i < replies.Length; i++)
            {
                ThisX.replies[i] = replies[i].WrappedReply1;
            }
            return base.ReturnX();
        }
    }
}
