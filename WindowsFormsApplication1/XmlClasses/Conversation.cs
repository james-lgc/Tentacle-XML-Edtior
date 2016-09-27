using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using WindowsFormsApplication1;
using System;

[System.Serializable]
public class Conversation : ConversationBase<StoryStage>, IReturnable
{
    [XmlAttribute("name")]
    public string name { get; set; }

    [XmlArray("StoryStages")]
    [XmlArrayItem("StoryStage")]
    protected override List<StoryStage> returnables { get; set; }

}

[System.Serializable]
public class StoryStage : ConversationBase<ConversationStage>, IReturnable
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
	protected override List<ConversationStage> returnables { get; set; }

}

[System.Serializable]
public class ConversationStage : ConversationBase<Line>, IReturnable
{
    //[XmlElementAttribute("id")]
    [XmlIgnore]
    public int id { get; set; }

    [XmlArray("Lines")]
	[XmlArrayItem("Line")]
	protected override List<Line> returnables { get; set; }

}

[System.Serializable]
public class Line : ConversationBase<Reply>, IReturnable
{
    //[XmlElementAttribute("id")]
    [XmlIgnore]
    public int id { get; set; }

    [XmlElement("LineText")]
	public string lineText { get; set; }

    [XmlArray("Replies")]
	[XmlArrayItem("Reply")]
	protected override List<Reply> returnables { get; set; }

    public override void Build()
    {
        returnables = new List<Reply>();
    }
}

[System.Serializable]
public class Reply : ConversationBase<Reply>, IReturnable
{
    [XmlElement("ReplyText")]
    public string replyText { get; set; }

    [XmlIgnore]
    public override List<IReturnable> Returnables { get { return null; } set { } }

    public override IReturnable GetNewReturnable()
    {
        return null;
    }

    public override void ReplaceContents(List<IReturnable> newContents)
    {
        return;
    }

    public override void Build()
    {
        return;
    }
}
