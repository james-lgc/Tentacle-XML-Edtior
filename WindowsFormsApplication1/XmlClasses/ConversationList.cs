using System.Collections.Generic;
using System.Linq;
using TentacleXMLEditor;
using System.Xml.Serialization;
using System.Xml;



[System.Serializable()]
[XmlRoot("ConversationList")]
public class ConversationList : ConversationBase<Conversation>, IReturnable
{
    [XmlArray("Conversations")]
    [XmlArrayItem("Conversation", typeof(Conversation))]
    public override List<Conversation> returnables { get; set; }

    public override void Build()
    {
        if (returnables == null)
        {
            base.Build();
        }
    }
}
