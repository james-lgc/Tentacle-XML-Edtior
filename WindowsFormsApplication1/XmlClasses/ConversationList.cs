using System.Collections.Generic;
using WindowsFormsApplication1;
using System.Xml.Serialization;
using System.Xml;

[XmlRoot("ConversationListCollection")]
[System.Serializable]
public class ConversationList<X> : IReturnable<X> where X : ConversationList<X>
{
	[XmlArray("Conversations")]
	[XmlArrayItem("Conversation")]
	public Conversation<StoryStage<ConversationStage<Line<Reply<string>>>>>[] conversations;

    public IReturnable<X>[] Returnables { get { return conversations as IReturnable<X>[]; } set { } }

    public void Build()
    {
        conversations = new Conversation<StoryStage<ConversationStage<Line<Reply<string>>>>>[1];
        conversations[0] = new Conversation<StoryStage<ConversationStage<Line<Reply<string>>>>>();
        conversations[0].Build();
    }
}