using System.Xml;
using System.Xml.Serialization;
using WindowsFormsApplication1;

[System.Serializable]
public class Conversation : ConversationList, IReturnable
{
    [XmlAttribute("name")]
    public string name { get; set; }

    [XmlArray("StoryStages")]
    [XmlArrayItem("StoryStage")]
    public StoryStage[] storyStages { get; set; }

    [XmlIgnore]
    public new IReturnable[] Returnables { get { return storyStages as IReturnable[]; } set { storyStages = value as StoryStage[]; } }

    public new void Build()
    {
        storyStages = new StoryStage[1];
        storyStages[0] = new StoryStage();
        storyStages[0].Build();
    }

}

[System.Serializable]
public class StoryStage : Conversation, IReturnable
{
    //[XmlAttribute("id")]
    [XmlIgnore]
    public int id { get; set; }

    [XmlElement("StoryThread")]
	public string storyThread { get; set; }

    [XmlElement("StageNumber")]
	public int stageNumber { get; set; }


    [XmlArray("ConversationStages")]
	[XmlArrayItem("ConversationStage")]
	public ConversationStage[] conversationStages { get; set; }

    [XmlIgnore]
    public new IReturnable[] Returnables{ get { return conversationStages as IReturnable[]; } set { } }

    public new void Build()
    {
        conversationStages = new ConversationStage[1];
        conversationStages[0] = new ConversationStage();
        conversationStages[0].Build();
    }

}

[System.Serializable]
public class ConversationStage : StoryStage, IReturnable
{
    //[XmlElementAttribute("id")]
    [XmlIgnore]
    public new int id { get; set; }

    [XmlArray("Lines")]
	[XmlArrayItem("Line")]

	public Line[] lines { get; set; }

    [XmlIgnore]
    public new IReturnable[] Returnables { get { return lines as IReturnable[]; } set { } }

    public new void Build()
    {
        lines = new Line[1];
        lines[0] = new Line();
        lines[0].Build();
    }
}

[System.Serializable]
public class Line : ConversationStage, IReturnable
{
    //[XmlElementAttribute("id")]
    [XmlIgnore]
    public new int id { get; set; }

    [XmlElement("LineText")]
	public string lineText { get; set; }

    [XmlArray("Replies")]
	[XmlArrayItem("Reply")]
	public Reply[] replies { get; set; }

    [XmlIgnore]
    public new IReturnable[] Returnables { get { return replies as IReturnable[]; } set { } }

    public new void Build()
    {
        replies = new Reply[0];
        //replies[0].Build();
    }
}

[System.Serializable]
public class Reply : Line, IReturnable
{
    [XmlElement("Reply")]
    public string replyText { get; set; }

    private WrappedReply[] wrappedReplies;

    [XmlIgnore]
    public IReturnable[] WrappedReplies { get { Build(); return wrappedReplies; } set { } }

    [XmlIgnore]
    public new IReturnable[] Returnables { get { return WrappedReplies; } set { } }

    public new void Build()
    {
        wrappedReplies = new WrappedReply[1];

    }
}
