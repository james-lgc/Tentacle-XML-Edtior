using System.Collections.Generic;
using WindowsFormsApplication1;
using System.Xml.Serialization;
using System.Xml;

[XmlRoot("ConversationListCollection")]
[System.Serializable]
public class ConversationList : IReturnable
{
	[XmlArray("Conversations")]
	[XmlArrayItem("Conversation")]
	public Conversation[] conversations { get; set; }

    [XmlIgnore]
    public IReturnable[] Returnables { get { return conversations as IReturnable[]; } set { conversations = value as Conversation[]; } }

    public void Build()
    {
        conversations = new Conversation[1];
        conversations[0] = new Conversation();
        conversations[0].Build();
    }
}