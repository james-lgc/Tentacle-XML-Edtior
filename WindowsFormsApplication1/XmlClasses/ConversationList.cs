using System.Collections.Generic;
using System.Linq;
using WindowsFormsApplication1;
using System.Xml.Serialization;
using System.Xml;



[System.Serializable()]
[XmlRoot("ConversationList")]
public class ConversationList : ConversationBase<Conversation>, IReturnable
{
    [XmlArray("Conversations")]
    [XmlArrayItem("Conversation", typeof(Conversation))]
    public override List<Conversation> returnables { get; set; }

    public override IReturnable GetNewReturnable()
    {
        Conversation newT = new Conversation();
        returnables.Add(newT);
        newT.Build();
        return newT as IReturnable;
    }

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
