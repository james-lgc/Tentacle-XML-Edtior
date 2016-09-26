using System.Xml;
using System.Xml.Serialization;
using WindowsFormsApplication1;

[System.Serializable]
public class Conversation : IReturnable
{
    [XmlAttribute("name")]
    public string name { get; set; }

    [XmlArray("StoryStages")]
    [XmlArrayItem("StoryStage")]
    public StoryStage[] storyStages { get; set; }

    [XmlIgnore]
    public IReturnable[] Returnables { get { return storyStages as IReturnable[]; } set { storyStages = value as StoryStage[]; } }

    public IReturnable GetNewReturnable()
    {
        return new StoryStage() as IReturnable;
    }

    public void Build()
    {
        storyStages = new StoryStage[1];
        storyStages[0] = new StoryStage();
        storyStages[0].Build();
    }

}

[System.Serializable]
public class StoryStage : IReturnable
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
    public IReturnable[] Returnables{ get { return conversationStages as IReturnable[]; } set { } }

    public IReturnable GetNewReturnable()
    {
        return new ConversationStage() as IReturnable;
    }

    public void Build()
    {
        conversationStages = new ConversationStage[1];
        conversationStages[0] = new ConversationStage();
        conversationStages[0].Build();
    }

}

[System.Serializable]
public class ConversationStage : IReturnable
{
    //[XmlElementAttribute("id")]
    [XmlIgnore]
    public int id { get; set; }

    [XmlArray("Lines")]
	[XmlArrayItem("Line")]

	public Line[] lines { get; set; }

    [XmlIgnore]
    public IReturnable[] Returnables { get { return lines as IReturnable[]; } set { } }

    public IReturnable GetNewReturnable()
    {
        return new Line() as IReturnable;
    }

    public void Build()
    {
        lines = new Line[1];
        lines[0] = new Line();
        lines[0].Build();
    }
}

[System.Serializable]
public class Line : IReturnable
{
    //[XmlElementAttribute("id")]
    [XmlIgnore]
    public int id { get; set; }

    [XmlElement("LineText")]
	public string lineText { get; set; }

    [XmlArray("Replies")]
	[XmlArrayItem("Reply")]
	public string[] replies { get; set; }

    [XmlIgnore]
    public Reply[] repliesR { get; set; }

    [XmlIgnore]
    public IReturnable[] Returnables
    {
        get
        {
            Build();
            return repliesR as IReturnable[];
        }
        set { }
    }

    public IReturnable GetNewReturnable()
    {
        return new Reply() as IReturnable;
    }

    public void Build()
    {
        if (replies != null)
        {
            repliesR = new Reply[replies.Length];
            for (int i = 0; i < replies.Length; i++)
            {
                repliesR[i] = new Reply();
                repliesR[i].replyText = replies[i];
            }
        }
        else
        {
            //replies = new string[0];
            repliesR = new Reply[0];
            //repliesR[0] = new Reply();
            //repliesR[0].Build("");
        }
        //replies[0].Build();
    }
}

[System.Serializable]
public class Reply : IReturnable
{
    [XmlIgnore]
    public string replyText { get; set; }

    [XmlIgnore]
    public IReturnable[] Returnables { get { return null; } set { } }

    public IReturnable GetNewReturnable()
    {
        return null;
    }

    public Reply()
    {

    }

    public void Build(string sentText)
    {
        replyText = sentText;
    }
}
