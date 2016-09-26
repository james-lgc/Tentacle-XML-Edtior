using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using WindowsFormsApplication1;
using System;

[System.Serializable]
public class Conversation : IReturnable
{
    [XmlAttribute("name")]
    public string name { get; set; }

    [XmlArray("StoryStages")]
    [XmlArrayItem("StoryStage")]
    public List<StoryStage> storyStages { get; set; }

    [XmlIgnore]
    public List<IReturnable> Returnables { get { return storyStages.Cast<IReturnable>().ToList(); } set { storyStages = value.Cast<StoryStage>().ToList(); } }

    public IReturnable GetNewReturnable()
    {
        StoryStage newStoryStage = new StoryStage();
        storyStages.Add(newStoryStage);
        newStoryStage.Build();
        return newStoryStage as IReturnable;
    }

    public void ReplaceContents(List<IReturnable> newContents)
    {
        storyStages = newContents.Cast<StoryStage>().ToList();
    }

    public void Build()
    {
        storyStages = new List<StoryStage>();
        StoryStage newStoryStage = new StoryStage();
        storyStages.Add(newStoryStage);
        newStoryStage.Build();
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
	public List<ConversationStage> conversationStages { get; set; }

    [XmlIgnore]
    public List<IReturnable> Returnables{ get { return conversationStages.Cast<IReturnable>().ToList(); } set { conversationStages = value.Cast<ConversationStage>().ToList(); } }

    public IReturnable GetNewReturnable()
    {
        //Build();
        ConversationStage newConversationStage = new ConversationStage();
        conversationStages.Add(newConversationStage);
        newConversationStage.Build();
        return newConversationStage as IReturnable;
    }

    public void ReplaceContents(List<IReturnable> newContents)
    {
        conversationStages = newContents.Cast<ConversationStage>().ToList();
    }

    public void Build()
    {
        conversationStages = new List<ConversationStage>();
        ConversationStage newConversationStage = new ConversationStage();
        conversationStages.Add(newConversationStage);
        newConversationStage.Build();
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
	public List<Line> lines { get; set; }

    [XmlIgnore]
    public List<IReturnable> Returnables { get { return lines.Cast<IReturnable>().ToList(); } set { lines = value.Cast<Line>().ToList(); } }

    public IReturnable GetNewReturnable()
    {
        Line newLine = new Line();
        lines.Add(newLine);
        newLine.Build();
        return newLine as IReturnable;
    }

    public void ReplaceContents(List<IReturnable> newContents)
    {
        lines = newContents.Cast<Line>().ToList();
    }

    public void Build()
    {
        lines = new List<Line>();
        Line newLine = new Line();
        lines.Add(newLine);
        newLine.Build();
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
	public List<Reply> replies { get; set; }

    [XmlIgnore]
    public List<IReturnable> Returnables { get { return replies.Cast<IReturnable>().ToList(); } set { replies = value.Cast<Reply>().ToList(); } }

    public IReturnable GetNewReturnable()
    {
        Reply newReply = new Reply();
        replies.Add(newReply);
        newReply.Build();
        return new Reply() as IReturnable;
    }

    public void ReplaceContents(List<IReturnable> newContents)
    {
        replies = newContents.Cast<Reply>().ToList();
    }

    public void Build()
    {
        replies = new List<Reply>();
    }
}

[System.Serializable]
public class Reply : IReturnable
{
    [XmlElement("ReplyText")]
    public string replyText { get; set; }

    [XmlIgnore]
    public List<IReturnable> Returnables { get { return null; } set { } }

    public IReturnable GetNewReturnable()
    {
        return null;
    }

    public void ReplaceContents(List<IReturnable> newContents)
    {

    }

    public void Build()
    {
        //replyText = "";
    }
}
