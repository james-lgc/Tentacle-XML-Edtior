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
        public ReplyTable(Form1 form, LineBox lineBox, string[] replies, Line line)
        {
            string[] labels = new string[] { "Reply" };
            if (replies != null)
            {
                base.SetUp(form, lineBox.cTable, replies.Length, 2, 1, replies, labels);
                //cTable.panel.DataBindings.Add()
                for (int i = 0; i < xArray.Length; i++)
                {
                    //ReplyBox= new LineBox(form, this, i, lines[i]);
                    TextBox textBox = new TextBox();
                    textBox.Parent = lineBox.cTable.panel;
                    StringWrapper stringWrapper = new StringWrapper();
                    stringWrapper.wrappedString = line.replies[i];
                    textBox.DataBindings.Add("Text", stringWrapper, "wrappedString", false, DataSourceUpdateMode.OnPropertyChanged);
                    textBox.Dock = DockStyle.Fill;
                    cTable.panel.SetRow(textBox, i);
                    cTable.panel.SetColumn(textBox, 1);
                    cTable.panel.Controls.Add(textBox);
                }
            }
            //base.Expand();
        }
    }
}

public class StringWrapper
{
    public string wrappedString { get; set; }
}
