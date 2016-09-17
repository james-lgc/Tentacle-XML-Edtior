using System.Xml;
using System.Xml.Serialization;

[System.Serializable]
public class Conversation{

	[XmlAttribute("name")]
	public string name;

	[XmlArray("StoryStages")]
	[XmlArrayItem("StoryStage")]
	public StoryStage[] storyStages;

}

[System.Serializable]
public class StoryStage{

	[XmlAttribute("id")]
	public int id;

	[XmlElement("StoryThread")]
	public string storyThread;

	[XmlElement("StageNumber")]
	public int stageNumber;


	[XmlArray("ConversationStages")]
	[XmlArrayItem("ConversationStage")]
	public ConversationStage[] conversationStages;

}

[System.Serializable]
public class ConversationStage{

	[XmlElementAttribute("id")]
	public int id;

	[XmlArray("Lines")]
	[XmlArrayItem("Line")]
	public Line[] lines;

}

[System.Serializable]
public class Line{

	[XmlElementAttribute("id")]
	public int id;

	[XmlElement("LineText")]
	public string lineText;

	[XmlArray("Replies")]
	[XmlArrayItem("Reply")]
	public string[] replies;

}
