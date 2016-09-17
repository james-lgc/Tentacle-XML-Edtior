using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;

[XmlRoot("ConversationListCollection")]
[System.Serializable]
public class ConversationList {
	
	[XmlArray("Conversations")]
	[XmlArrayItem("Conversation")]
	public Conversation[] conversations;

}