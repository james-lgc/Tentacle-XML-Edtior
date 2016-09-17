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
        private TextBox textBox;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                textBox = new TextBox();
                this.textBox.Text = "Text";
                this.textBox.Location = new System.Drawing.Point(10, 25);
                this.textBox.Size = new System.Drawing.Size(70, 20);
                this.Controls.Add(textBox);
                this.textBox.BringToFront();
                Application.DoEvents();
            }
        }
    }

}
