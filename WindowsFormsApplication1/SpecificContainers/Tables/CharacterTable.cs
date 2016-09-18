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
            base.SetUp(form, mainDisplay.container, conversations.Length, 1, conversations);
            for (int i = 0; i < xArray.Length; i++)
            {
                CharacterBox characterBox = new CharacterBox(form, this, i, conversations[i]);
            }
            base.Expand();
        }
    }
}
