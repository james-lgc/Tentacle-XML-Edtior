using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private MainDisplay mainDisplay;
        MenuStrip menuStrip;

        public Form1()
        {
            InitializeComponent();
            this.BackColor = ColourManager.backGroundColour;
            //WindowState = FormWindowState.Maximized;
            menuStrip = new MenuStrip();
            menuStrip.Dock = DockStyle.Top;
            menuStrip.SendToBack();
            this.Controls.Add(menuStrip);

            ToolStripMenuItem fileMenu = new ToolStripMenuItem();
            fileMenu.Text = "File";
            ToolStripMenuItem loadButton = new ToolStripMenuItem();
            loadButton.Text = "Load";
            ToolStripMenuItem newButton = new ToolStripMenuItem();
            newButton.Text = "New";

            menuStrip.Items.Add(fileMenu);
            
            fileMenu.DropDownItems.Add(loadButton);
            fileMenu.DropDownItems.Add(newButton);
            loadButton.Click += BypassLoad;
            newButton.Click += CreateNew;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BypassLoad(sender, e);
            return;

            DialogResult open = openFileDialog1.ShowDialog();
            if (open == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                FileStream reader = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(typeof(ConversationList));
                ConversationList cList = serializer.Deserialize(reader) as ConversationList;
                reader.Close();

                //XmlDocument doc = new XmlDocument();

                mainDisplay = new MainDisplay(this, cList);
                AutoScroll = true;
                this.AutoScroll = true;
                Application.DoEvents();
            }
        }

        private void BypassLoad(object sender, EventArgs e)
        {
            string path = "C:/Users/James/Documents/conversations.xml";
            FileStream reader = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            XmlSerializer serializer = new XmlSerializer(typeof(ConversationList));
            ConversationList cList = serializer.Deserialize(reader) as ConversationList;
            reader.Close();

            //XmlDocument doc = new XmlDocument();

            mainDisplay = new MainDisplay(this, cList);
            AutoScroll = true;
            Application.DoEvents();
        }

        private void CreateNew(object sender, EventArgs e)
        {
            ConversationList cList = new ConversationList();
            cList.Build();
            mainDisplay = null;
            mainDisplay = new MainDisplay(this, cList);

        }
    }

}
