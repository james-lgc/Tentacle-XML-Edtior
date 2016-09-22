using System.Collections.Generic;
using WindowsFormsApplication1;
using System.Xml.Serialization;
using System.Xml;

[XmlRoot("ConversationListCollection")]
[System.Serializable]
public class ConversationList : IReturnable<Conversation>
{
	[XmlArray("Conversations")]
	[XmlArrayItem("Conversation")]
	public Conversation[] conversations { get; set; }

    public IReturnable<Conversation>[] Returnables { get { return conversations as IReturnable<Conversation>[]; } set { conversations = value as Conversation[]; } }

    public void Build()
    {
        conversations = new Conversation[1];
        conversations[0] = new Conversation();
        conversations[0].Build();
    }
}