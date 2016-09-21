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
    public partial class TentacleDoc : Form
    {
        private MainDisplay mainDisplay;
        MenuStrip menuStrip;
        public LoadingPanel loadingPanel;

        public TentacleDoc()
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

            ToolStripMenuItem newButton = new ToolStripMenuItem();
            newButton.Text = "New";
            ToolStripMenuItem saveButton = new ToolStripMenuItem();
            saveButton.Text = "Save";
            ToolStripMenuItem loadButton = new ToolStripMenuItem();
            loadButton.Text = "Load";
            

            menuStrip.Items.Add(fileMenu);

            fileMenu.DropDownItems.Add(newButton);
            fileMenu.DropDownItems.Add(saveButton);
            fileMenu.DropDownItems.Add(loadButton);
            
            newButton.Click += CreateNew;
            saveButton.Click += SaveFile;
            loadButton.Click += BypassLoad;
            
        }

        /*private void button1_Click(object sender, EventArgs e)
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
        }*/

        private void BypassLoad(object sender, EventArgs e)
        {
            //string path = "C:/Users/James/Documents/conversations.xml";
            DialogResult open = openFileDialog1.ShowDialog();
            if (open == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                FileStream reader = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(typeof(ConversationList<Conversation<StoryStage<ConversationStage<Line<Reply<string>>>>>>));
                ConversationList<Conversation<StoryStage<ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>>>> cList = serializer.Deserialize(reader) as ConversationList<Conversation<StoryStage<ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>>>>;
                reader.Close();

                //XmlDocument doc = new XmlDocument();

                mainDisplay = new MainDisplay(cList, this, null, 0, "Conversations", 1, "Conversation");
                AutoScroll = true;
                Application.DoEvents();
            }
        }

        private void CreateNew(object sender, EventArgs e)
        {
            ConversationList<Conversation<StoryStage<ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>>>> cList = new ConversationList<Conversation<StoryStage<ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>>>>();
            cList.Build();
            mainDisplay = null;
            mainDisplay = new MainDisplay(cList, this, null, 0, "Conversations", 1, "Conversation");
        }

        private void SaveFile(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            DialogResult save = saveFileDialog1.ShowDialog();

            if (save == DialogResult.OK)
            {
                ConversationList<Conversation<StoryStage<ConversationStage<Line<Reply<string>>>>>> saveFile = new ConversationList<Conversation<StoryStage<ConversationStage<Line<Reply<string>>>>>>();
                saveFile.conversations = mainDisplay.characterTable.ReturnContents;

                string path = saveFileDialog1.FileName;
                //string path = "C:/Users/James/Documents/conversationsTestSave.xml";
                FileStream stream = new FileStream(path, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(ConversationList<Conversation<StoryStage<ConversationStage<Line<Reply<string>>>>>>));
                serializer.Serialize(stream, saveFile);
                stream.Close();
            }
        }

        private void TentacleDoc_Load(object sender, EventArgs e)
        {

        }
    }

}
