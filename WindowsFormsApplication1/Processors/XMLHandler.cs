using System;
using TentacleXMLEditor.ConversationSystem;
using System.Xml.Serialization;

namespace TentacleXMLEditor.Processors
{
    class XMLHandler
    {
        public static XmlSerializer Serializer { get; private set; }

        public XMLHandler()
        {
            Serializer = new XmlSerializer(typeof(ConversationList), new Type[] { typeof(Conversation), typeof(StoryStage), typeof(ConversationStage), typeof(Line), typeof(Reply) });
        }
    }
}
