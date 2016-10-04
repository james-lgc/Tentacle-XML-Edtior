using System;
using TentacleConversationXML;
using System.Xml.Serialization;

namespace TentacleConversationXML
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
