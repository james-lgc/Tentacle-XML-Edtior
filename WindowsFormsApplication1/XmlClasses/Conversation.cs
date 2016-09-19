using System.Xml;
using System.Xml.Serialization;

[System.Serializable]
public class Conversation{

	[XmlAttribute("name")]
    public string name { get; set; }

	[XmlArray("StoryStages")]
	[XmlArrayItem("StoryStage")]
	public StoryStage[] storyStages;

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

}

[System.Serializable]
public class ConversationStage{

	[XmlElementAttribute("id")]
	public int id { get; set; }

    [XmlArray("Lines")]
	[XmlArrayItem("Line")]
	public Line[] lines;

}

[System.Serializable]
public class Line{

	[XmlElementAttribute("id")]
	public int id { get; set; }

    [XmlElement("LineText")]
	public string lineText { get; set; }

    [XmlArray("Replies")]
	[XmlArrayItem("Reply")]
	public Reply[] replies { get; set; }

}

[System.Serializable]
public class Reply
{

    [XmlElementAttribute("id")]
    public int id { get; set; }

    [XmlElement("LineText")]
    public string lineText { get; set; }

    [XmlArray("Replies")]
    [XmlArrayItem("Reply")]
    public string[] replies { get; set; }

}
