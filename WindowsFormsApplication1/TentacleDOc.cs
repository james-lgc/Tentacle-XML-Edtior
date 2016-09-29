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

namespace TentacleXMLEditor
{
    public delegate void LoadingHandler(object sender, EventArgs e);

    public partial class TentacleDoc : Form, IColourable
    {
        private XMLHandler Handler { get; set; }
        public TwoToneColour TTColour { get; set; }
        private string CurrentFilePath { get; set; }
        TentacleMenuStrip MenuStrip1 { get; set; }
        public TentacleLoadingPanel loadingPanel;
        UIBox mainDisplay;

        public event LoadingHandler BeginLoading;
        public event LoadingHandler EndLoading;

        public TentacleDoc()
        {
            InitializeComponent();
            ColourManager.SetNightTheme();
            SetColours();
            //WindowState = FormWindowState.Maximized;
            MenuStrip1 = new TentacleMenuStrip(this);
            Handler = new XMLHandler();
        }

        public void CreateNew(object sender, EventArgs e)
        {
            DisposeMainDisplay();
            CurrentFilePath = null;
            ConversationList cList = new ConversationList();
            BoxInformationContainer boxInfos = new BoxInformationContainer();
            cList.Build();
            //BuildLoadingPanel(cList);
            mainDisplay = new UIBox(cList, null, 0, boxInfos, 0, this);
            mainDisplay.ChildTable.TentacleTable1.panel.AutoScroll = true;
            AutoScroll = true;
            //EndLoad();
        }

        public void SaveAs(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            DialogResult save = saveFileDialog1.ShowDialog();

            if (save == DialogResult.OK)
            {
                SaveFile(saveFileDialog1.FileName);
            }
        }

        public void Save(object sender, EventArgs e)
        {
            if (CurrentFilePath != null)
            {
                SaveFile(CurrentFilePath);
            }
        }

        private void SaveFile(string path)
        {
            ConversationList saveFile = mainDisplay.ThisX as ConversationList;
            FileStream stream = new FileStream(path, FileMode.Create);
            Handler.Serializer.Serialize(stream, saveFile);
            stream.Close();
        }

        public void BypassLoad(object sender, EventArgs e)
        {
            DialogResult open = openFileDialog1.ShowDialog();
            if (open == DialogResult.OK)
            {
                DisposeMainDisplay();
                string path = openFileDialog1.FileName;
                CurrentFilePath = path;
                FileStream reader = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                ConversationList cList = (ConversationList)Handler.Serializer.Deserialize(reader) as ConversationList;
                reader.Close();
                BoxInformationContainer boxInfos = new BoxInformationContainer();
                //BuildLoadingPanel(cList);
                mainDisplay = new UIBox(cList, null, 0, boxInfos, 0, this);
                mainDisplay.ChildTable.TentacleTable1.panel.AutoScroll = true;
                AutoScroll = true;
                Application.DoEvents();
                //EndLoad();
            }
        }

        private void BuildLoadingPanel(ConversationList cList)
        {
            loadingPanel = new TentacleLoadingPanel(this, cList);
            if (BeginLoading != null)
            {
                BeginLoading(this, new EventArgs());
            }
        }

        private void DisposeMainDisplay()
        {
            if (mainDisplay != null)
            {
                Controls.Remove(mainDisplay.GroupBox1);
                mainDisplay.GroupBox1.Dispose();
                mainDisplay = null;
            }
        }

        private void EndLoad()
        {
            if (EndLoading != null)
            {
                EndLoading(this, new EventArgs());
            }
        }

        public void IncreaseLoadingProgress()
        {
            if (loadingPanel != null && loadingPanel.Visible == true)
            {
                loadingPanel.IncreaseProgress();
            }
        }

        public void SetColours()
        {
            TTColour = ColourManager.CurrentTheme.DarkBackGround;
            Colourizer.Colourize(this, TTColour);
        }
    }

}
