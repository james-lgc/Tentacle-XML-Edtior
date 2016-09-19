using System.Xml;
using System.Xml.Serialization;

[System.Serializable]
public class Conversation{

	[XmlAttribute("name")]
    public string name { get; set; }

	[XmlArray("StoryStages")]
	[XmlArrayItem("StoryStage")]
	public StoryStage[] storyStages;

    public void Build()
    {
        storyStages = new StoryStage[1];
        storyStages[0] = new StoryStage();
        storyStages[0].Build();
    }

}

[System.Serializable]
public class StoryStage{

	[XmlAttribute("id")]
	public int id { get; set; }

    [XmlElement("StoryThread")]
	public string storyThread { get; set; }

    [XmlElement("StageNumber")]
	public int stageNumber { get; set; }


    [XmlArray("ConversationStages")]
	[XmlArrayItem("ConversationStage")]
	public ConversationStage[] conversationStages;

    public void Build()
    {
        conversationStages = new ConversationStage[1];
        conversationStages[0] = new ConversationStage();
        conversationStages[0].Build();
    }

}

[System.Serializable]
public class ConversationStage{

	[XmlElementAttribute("id")]
	public int id { get; set; }

    [XmlArray("Lines")]
	[XmlArrayItem("Line")]
	public Line[] lines;

    public void Build()
    {
        lines = new Line[1];
        lines[0] = new Line();
        lines[0].Build();
    }
}

[System.Serializable]
public class Line{

	[XmlElementAttribute("id")]
	public int id { get; set; }

    [XmlElement("LineText")]
	public string lineText { get; set; }

    [XmlArray("Replies")]
	[XmlArrayItem("Reply")]
	public string[] replies { get; set; }

    public void Build()
    {
        replies = new string[0];
    }
}
