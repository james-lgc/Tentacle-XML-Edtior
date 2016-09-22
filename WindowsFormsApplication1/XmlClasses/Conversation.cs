using System.Xml;
using System.Xml.Serialization;
using WindowsFormsApplication1;

[System.Serializable]
public class Conversation : ConversationList, IReturnable<StoryStage>
{
    [XmlAttribute("name")]
    public string name { get; set; }

    [XmlArray("StoryStages")]
    [XmlArrayItem("StoryStage")]
    public StoryStage[] storyStages { get; set; }
    public new IReturnable<StoryStage>[] Returnables { get { return storyStages as IReturnable<StoryStage>[]; } set { storyStages = value as StoryStage[]; } }

    public new void Build()
    {
        storyStages = new StoryStage[1];
        storyStages[0] = new StoryStage();
        storyStages[0].Build();
    }

}

[System.Serializable]
public class StoryStage : Conversation, IReturnable<ConversationStage>
{
	[XmlAttribute("id")]
	public int id { get; set; }

    [XmlElement("StoryThread")]
	public string storyThread { get; set; }

    [XmlElement("StageNumber")]
	public int stageNumber { get; set; }


    [XmlArray("ConversationStages")]
	[XmlArrayItem("ConversationStage")]
	public ConversationStage[] conversationStages { get; set; }

    public new IReturnable<ConversationStage>[] Returnables{ get { return conversationStages as IReturnable<ConversationStage>[]; } set { } }

    public new void Build()
    {
        conversationStages = new ConversationStage[1];
        conversationStages[0] = new ConversationStage();
        conversationStages[0].Build();
    }

}

[System.Serializable]
public class ConversationStage : StoryStage, IReturnable<Line>
{
	[XmlElementAttribute("id")]
	public int id { get; set; }

    [XmlArray("Lines")]
	[XmlArrayItem("Line")]

	public Line[] lines { get; set; }

    public new IReturnable<Line>[] Returnables { get { return lines as IReturnable<Line>[]; } set { } }

    public new void Build()
    {
        lines = new Line[1];
        lines[0] = new Line();
        lines[0].Build();
    }
}

[System.Serializable]
public class Line : ConversationStage, IReturnable<Reply>
{
	[XmlElementAttribute("id")]
	public int id { get; set; }

    [XmlElement("LineText")]
	public string lineText { get; set; }

    [XmlArray("Replies")]
	[XmlArrayItem("Reply")]
	public Reply[] replies { get; set; }

    public new IReturnable<Reply>[] Returnables { get { return replies as IReturnable<Reply>[]; } set { } }

    public new void Build()
    {
        replies = new Reply[0];
        //replies[0].Build();
    }
}

public class Reply : Line, IReturnable<WrappedReply>
{
    [XmlElement("Reply")]
    public string replyText { get; set; }

    public new IReturnable<WrappedReply>[] Returnables { get { return null; } set { } }

    public new void Build()
    {

    }
}
