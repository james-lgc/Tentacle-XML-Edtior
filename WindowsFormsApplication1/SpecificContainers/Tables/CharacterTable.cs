using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class CharacterTable : UITable<Conversation>
    {
        public CharacterTable(Form1 form, MainDisplay mainDisplay, Conversation[] conversations)
        {
            //string[] labels = new string[] { "name" };
            base.SetUp(form, this, mainDisplay.container, conversations.Length, 1, 1, conversations, null, "Conversation");
            for (int i = 0; i < xArray.Length; i++)
            {
                CharacterBox characterBox = new CharacterBox(form, this, i, conversations[i]);
            }
            cTable.panel.AutoScroll = true;
            base.Expand();
            //cTable.panel.AutoScroll = true;
        }

        public override void AddRow(Object sender, EventArgs e)
        {
            base.AddRow(sender, e);
            base.AddLabelWithText("Name");
            newX = new Conversation();
            newX.Build();
            CharacterBox characterBox = new CharacterBox(form1, this, cTable.panel.RowCount - 2, newX);
        }
    }
}
