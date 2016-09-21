using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class ReplyTable : UITable<WrappedReply>
    {

        private LineBox lineBox;

        public ReplyTable(TentacleDoc form, LineBox sentLineBox, WrappedReply[] replies, Line line)
        {
            lineBox = sentLineBox;
            //labelTexts = new string[] { "Reply" };
            if (replies != null)
            {
                base.SetUp(form, sentLineBox.GroupBox1, replies.Length, 1, replies, "Reply");
                for (int i = 0; i < xArray.Length; i++)
                {
                    RepliesBox repliesBox = new RepliesBox(form, this, i, xArray[i]);
                    StringWrapper stringWrapper = new StringWrapper();
                    stringWrapper.wrappedString = line.replies[i];
                    //AddTextBox(stringWrapper, i);
                    base.AddBox(repliesBox);
                }
            }
            else
            {
                replies = new WrappedReply[0];
                base.SetUp(form, sentLineBox.GroupBox1, replies.Length, 2, replies, "Reply");
            }
            cTable.panel.BringToFront();;
        }

        private void AddTextBox(StringWrapper stringWrapper, int rowNum)
        {
            TextBox textBox = new TextBox();
            textBox.ForeColor = ColourManager.backGroundColour;
            textBox.BackColor = ColourManager.textColour;
            textBox.Parent = cTable.panel;
            textBox.Dock = DockStyle.Fill;
            textBox.DataBindings.Add("Text", stringWrapper, "wrappedString", false, DataSourceUpdateMode.OnPropertyChanged);
            cTable.panel.SetRow(textBox, rowNum);
            cTable.panel.SetColumn(textBox, 1);
            cTable.panel.Controls.Add(textBox);
        }

        public override void AddRow(object sender, EventArgs e)
        {
            base.AddRow(sender, e);
            newX = new WrappedReply();
            newX.WrappedReply1 = "";
            //StringWrapper stringWrapper = new StringWrapper();
            //stringWrapper.wrappedString = newX;
            //AddTextBox(stringWrapper, cTable.panel.RowCount -1);
            RepliesBox replyBox = new RepliesBox(form1, this, cTable.panel.RowCount -1, newX);
            AddBox(replyBox);
        }
    }
}

public class StringWrapper
{
    public string wrappedString { get; set; }
}
