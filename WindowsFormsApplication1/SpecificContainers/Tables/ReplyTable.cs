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

        public ReplyTable(Form1 form, LineBox newLineBox, string[] replies, Line line)
        {
            lineBox = newLineBox;
            string[] labels = new string[] { "Reply" };
            if (replies != null)
            {
                base.SetUp(form, this, lineBox.cTable, replies.Length, 2, 1, replies, labels);
                //cTable.panel.DataBindings.Add()
                for (int i = 0; i < xArray.Length; i++)
                {
                    //ReplyBox= new LineBox(form, this, i, lines[i]);
                    StringWrapper stringWrapper = new StringWrapper();
                    stringWrapper.wrappedString = line.replies[i];
                    AddTextBox(stringWrapper, i);
                }
            }
            else
            {
                replies = new string[0];
                base.SetUp(form, this, lineBox.cTable, replies.Length, 2, 1, replies, labels);
            }
            //base.Expand();
        }

        private void AddTextBox(StringWrapper stringWrapper, int rowNum)
        {
            TextBox textBox = new TextBox();
            textBox.Parent = lineBox.cTable.panel;
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
        }
    }
}

public class StringWrapper
{
    public string wrappedString { get; set; }
}
