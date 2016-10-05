using System;
using TentacleConversationXML;
using TentacleXMLEditor.Structure;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TentacleXMLEditor.Processors
{
    public class FileManager
    {
        private TentacleDoc TentacleDoc1 { get; set; }
        private string CurrentFilePath { get; set; }
        private XmlSerializer serializer;

        public FileManager(TentacleDoc tDoc)
        {
            TentacleDoc1 = tDoc;
        }

        public ConversationList New()
        {
            CurrentFilePath = null;
            ConversationList cList = new ConversationList();
            BoxInformationContainer boxInfos = new BoxInformationContainer();
            cList.Build();
            return cList;
        }

        public void SaveAs(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            DialogResult save = saveFileDialog1.ShowDialog();

            if (save == DialogResult.OK)
            {
                SaveFile(saveFileDialog1.FileName);
            }
            saveFileDialog1.Dispose();
        }

        public void Save(object sender, EventArgs e)
        {
            if (CurrentFilePath != null)
            {
                SaveFile(CurrentFilePath);
            }
            else
            {
                SaveAs(sender, e);
            }
        }

        private void SaveFile(string path)
        {
            ConversationList saveFile = TentacleDoc1.MainDisplay.ThisX as ConversationList;
            FileStream stream = new FileStream(path, FileMode.Create);
            GetSerializer().Serialize(stream, saveFile);
            stream.Close();
        }

        public ConversationList Load()
        {
            string oldPath = CurrentFilePath;
            CurrentFilePath = null;
            Open();
            if (CurrentFilePath != null)
            {
                FileStream reader = new FileStream(CurrentFilePath, FileMode.Open, FileAccess.Read/*, FileShare.ReadWrite*/);
                ConversationList cList = (ConversationList)GetSerializer().Deserialize(reader) as ConversationList;
                reader.Close();
                return cList;
            }
            else
            {
                CurrentFilePath = oldPath;
                return null;
            }
        }

        public void Open()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult open = openFileDialog1.ShowDialog();
            if (open == DialogResult.OK)
            {
                CurrentFilePath = openFileDialog1.FileName;
            }
        }

        private XmlSerializer GetSerializer()
        {
            if (serializer == null)
            {
                serializer = new XmlSerializer(typeof(ConversationList), new Type[] { typeof(Conversation), typeof(StoryStage), typeof(ConversationStage), typeof(Line), typeof(Reply) });
            }
            return serializer;
        }
    }
}
