using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class ReplyTable : UITable<string>
    {

        private LineBox lineBox;

        public ReplyTable(Form1 form, LineBox sentLineBox, string[] replies, Line line)
        {
            lineBox = sentLineBox;
            string[] labels = new string[] { "Reply" };
            if (replies != null)
            {
                base.SetUp(form, this, lineBox.container, replies.Length, 2, 1, replies, labels, "Reply");
                for (int i = 0; i < xArray.Length; i++)
                {
                    RepliesBox repliesBox = new RepliesBox(form, this, i, replies[i]);
                    AddBox(repliesBox);
                    StringWrapper stringWrapper = new StringWrapper();
                    stringWrapper.wrappedString = line.replies[i];
                    AddTextBox(stringWrapper, i);
                    form.loadingPanel.IncreaseProgress();
                }
            }
            else
            {
                replies = new string[0];
                base.SetUp(form, this, lineBox.container, replies.Length, 2, 1, replies, labels, "Reply");
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
            newX = "";
            StringWrapper stringWrapper = new StringWrapper();
            stringWrapper.wrappedString = newX;
            AddTextBox(stringWrapper, cTable.panel.RowCount -1);
            RepliesBox replyBox = new RepliesBox(form1, this, cTable.panel.RowCount -2, newX);
            AddBox(replyBox);
        }
    }
}

public class StringWrapper
{
    public string wrappedString { get; set; }
}
