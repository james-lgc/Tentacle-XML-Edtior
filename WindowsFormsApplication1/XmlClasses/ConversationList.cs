using System.Collections.Generic;
using System.Linq;
using WindowsFormsApplication1;
using System.Xml.Serialization;
using System.Xml;

[XmlRoot("ConversationListCollection")]
[System.Serializable]
public class ConversationList : IReturnable
{
	[XmlArray("Conversations")]
	[XmlArrayItem("Conversation")]
	public List<Conversation> conversations { get; set; }

    [XmlIgnore]
    public List<IReturnable> Returnables { get { return conversations.Cast<IReturnable>().ToList(); } set { conversations = value.Cast<Conversation>().ToList(); } }

    public IReturnable GetNewReturnable()
    {
        //Build();
        Conversation newConversation = new Conversation();
        conversations.Add(newConversation);
        newConversation.Build();
        return newConversation as IReturnable;
    }

    public void ReplaceContents(List<IReturnable> newContents)
    {
        conversations = newContents.Cast<Conversation>().ToList();
    }

    public void AddToList(IReturnable)
    {

    }

    public void Build()
    {
        if (conversations == null)
        {
            conversations = new List<Conversation>();
            Conversation conversation = new Conversation();
            conversations.Add(conversation);
            conversation.Build();
        }
    }
}