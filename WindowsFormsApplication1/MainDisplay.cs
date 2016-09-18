﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class MainDisplay
    {
        public HeadedFixedContainer container;
        CharacterTable characterTable;

        public MainDisplay(Form1 form, ConversationList cList)
        {
            container = new HeadedFixedContainer(form, null, 0, "Conversations");
            container.panel.Dock = DockStyle.Fill;
            characterTable = new CharacterTable(form, this, cList.conversations);
            container.panel.AutoScroll = true;
            container.panel.Refresh();
        }
    }
}
