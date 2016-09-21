using System.Xml;
using System.Xml.Serialization;
using WindowsFormsApplication1;

[System.Serializable]
public class Conversation<X> : ConversationList<Conversation<X>>, IReturnable<X> where X : Conversation<X>
{
    [XmlAttribute("name")]
    public string name { get; set; }

    [XmlArray("StoryStages")]
    [XmlArrayItem("StoryStage")]
    public StoryStage<ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>>[] storyStages;
    public new IReturnable<X>[] Returnables { get { return storyStages as IReturnable<X>[]; } set { } }

    public void Build()
    {
        storyStages = new StoryStage<ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>>[1];
        storyStages[0] = new StoryStage<ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>>();
        storyStages[0].Build();
    }

}

[System.Serializable]
public class StoryStage<X> : Conversation<StoryStage<X>>, IReturnable<X> where X : StoryStage<X>
{
	[XmlAttribute("id")]
	public int id { get; set; }

    [XmlElement("StoryThread")]
	public string storyThread { get; set; }

    [XmlElement("StageNumber")]
	public int stageNumber { get; set; }


    [XmlArray("ConversationStages")]
	[XmlArrayItem("ConversationStage")]
	public ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>[] conversationStages;

    public new IReturnable<X>[] Returnables { get { return conversationStages as IReturnable<X>[]; } set { } }

    public new void Build()
    {
        conversationStages = new ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>[1];
        conversationStages[0] = new ConversationStage<Line<Reply<WrappedReply<ReplyString<string>>>>>();
        conversationStages[0].Build();
    }

}

[System.Serializable]
public class ConversationStage<X> : StoryStage<ConversationStage<X>>, IReturnable<X> where X : ConversationStage<X>
{
	[XmlElementAttribute("id")]
	public int id { get; set; }

    [XmlArray("Lines")]
	[XmlArrayItem("Line")]

	public Line<Reply<WrappedReply<ReplyString<string>>>>[] lines;

    public new IReturnable<X>[] Returnables { get { return lines as IReturnable<X>[]; } set { } }

    public new void Build()
    {
        lines = new Line<Reply<WrappedReply<ReplyString<string>>>>[1];
        lines[0] = new Line<Reply<WrappedReply<ReplyString<string>>>>();
        lines[0].Build();
    }
}

[System.Serializable]
public class Line<X> : ConversationStage<Line<X>>, IReturnable<X> where X : Line<X>
{
	[XmlElementAttribute("id")]
	public int id { get; set; }

    [XmlElement("LineText")]
	public string lineText { get; set; }

    [XmlArray("Replies")]
	[XmlArrayItem("Reply")]
	public Reply<WrappedReply<ReplyString<string>>>[] replies { get; set; }

    public new IReturnable<X>[] Returnables { get { return replies as IReturnable<X>[]; } set { } }

    public new void Build()
    {
        replies = new Reply<WrappedReply<ReplyString<string>>>[0];
    }
}

public class Reply<X> : Line<Reply<X>>, IReturnable<X>
{
    [XmlElement("Reply")]
    public string replyText { get; set; }

    public new IReturnable<X>[] Returnables { get { return null; } set { } }

    public new void Build()
    {

    }
}
