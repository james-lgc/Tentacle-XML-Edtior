using System.Collections.Generic;
using System.Linq;
using WindowsFormsApplication1;
using System.Xml.Serialization;
using System.Xml;

[XmlRoot("ConversationListCollection")]
[System.Serializable]
public class ConversationList : ConversationBase<Conversation>, IReturnable
{
	[XmlArray("Conversations")]
	[XmlArrayItem("Conversation")]
	protected override List<Conversation> returnables { get; set; }

    public override void Build()
    {
        if (returnables == null)
        {
            returnables = new List<Conversation>();
            Conversation conversation = new Conversation();
            returnables.Add(conversation);
            conversation.Build();
        }
    }
}