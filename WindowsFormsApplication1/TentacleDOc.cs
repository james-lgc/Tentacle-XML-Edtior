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
    public delegate ConversationList ProcessFile();

    public partial class TentacleDoc : Form, IColourable
    {
        private XMLHandler Handler { get; set; }
        public FileManager FileManager1 { get; set; }
        public TwoToneColour TTColour { get; set; }
        private string CurrentFilePath { get; set; }
        private TentacleMenuStrip MenuStrip1 { get; set; }
        public TentacleLoadingPanel LoadingPanel { get; set; }
        public UIBox MainDisplay { get; set; }

        public event LoadingHandler BeginLoading;
        public event LoadingHandler EndLoading;

        public TentacleDoc()
        {
            InitializeComponent();
            FileManager1 = new FileManager();
            ColourManager.SetNightTheme();
            SetColours();
            //WindowState = FormWindowState.Maximized;
            MenuStrip1 = new TentacleMenuStrip(this);
            Handler = new XMLHandler();
        }

        public void Build(Object sender, EventArgs e, ProcessFile processFile)
        {
            DisposeMainDisplay();
            BoxInformationContainer boxInfos = new BoxInformationContainer();
            ConversationList cList = processFile();
            if (cList != null)
            {
                MainDisplay = new UIBox(cList, null, 0, boxInfos, 0, this);
                MainDisplay.ChildTable.TentacleTable1.panel.AutoScroll = true;
                AutoScroll = true;
                Application.DoEvents();
            }
        }

        private void BuildLoadingPanel(ConversationList cList)
        {
            LoadingPanel = new TentacleLoadingPanel(this, cList);
            if (BeginLoading != null)
            {
                BeginLoading(this, new EventArgs());
            }
        }

        public void DisposeMainDisplay()
        {
            if (MainDisplay != null)
            {
                Controls.Remove(MainDisplay.GroupBox1);
                MainDisplay.GroupBox1.Dispose();
                MainDisplay = null;
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
            if (LoadingPanel != null && LoadingPanel.Visible == true)
            {
                LoadingPanel.IncreaseProgress();
            }
        }

        public void SetColours()
        {
            TTColour = ColourManager.CurrentTheme.DarkBackGround;
            Colourizer.Colourize(this, TTColour);
        }
    }

}
