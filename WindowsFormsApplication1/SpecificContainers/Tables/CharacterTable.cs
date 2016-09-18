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
            string[] labels = new string[] { "name" };
            base.SetUp(form, mainDisplay.container, conversations.Length, 1, 1, conversations, labels);
            for (int i = 0; i < xArray.Length; i++)
            {
                CharacterBox characterBox = new CharacterBox(form, this, i, conversations[i]);
            }
            base.Expand();
            //cTable.panel.AutoScroll = true;
        }
    }
}
