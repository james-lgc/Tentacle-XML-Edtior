using System;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentacleXMLEditor
{
    class XMLHandler
    {
        public XmlSerializer Serializer { get; private set; }

        public XMLHandler()
        {
            Serializer = new XmlSerializer(typeof(ConversationList), new Type[] { typeof(Conversation), typeof(StoryStage), typeof(ConversationStage), typeof(Line), typeof(Reply) });
        }
    }
}
