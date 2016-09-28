using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using WindowsFormsApplication1;
using System;


[System.Serializable]
[XmlType("Conversation")]
public class Conversation : ConversationBase<StoryStage>, IReturnable
{
    [XmlAttribute("name")]
    public string name { get; set; }

    [XmlArray("StoryStages")]
    [XmlArrayItem("StoryStage", typeof(StoryStage))]
    public override List<StoryStage> returnables { get; set; }

    public override IReturnable GetNewReturnable()
    {
        StoryStage newT = new StoryStage();
        returnables.Add(newT);
        newT.Build();
        return newT as IReturnable;
    }

    public override void Build()
    {
        returnables = new List<StoryStage>();
        StoryStage newT = new StoryStage();
        returnables.Add(newT);
        newT.Build();
    }

}

[System.Serializable]
[XmlType("StoryStage")]
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
    [XmlArrayItem("ConversationStage", typeof(ConversationStage))]
    public override List<ConversationStage> returnables { get; set; }

    public override IReturnable GetNewReturnable()
    {
        ConversationStage newT = new ConversationStage();
        returnables.Add(newT);
        newT.Build();
        return newT as IReturnable;
    }

    public override void Build()
    {
        returnables = new List<ConversationStage>();
        ConversationStage newT = new ConversationStage();
        returnables.Add(newT);
        newT.Build();
    }

}

[System.Serializable]
[XmlType("ConversationStage")]
public class ConversationStage : ConversationBase<Line>, IReturnable
{
    //[XmlElementAttribute("id")]
    [XmlIgnore]
    public int id { get; set; }

    [XmlArray("Lines")]
    [XmlArrayItem("Line", typeof(Line))]
    public override List<Line> returnables { get; set; }

    public override IReturnable GetNewReturnable()
    {
        Line newT = new Line();
        returnables.Add(newT);
        newT.Build();
        return newT as IReturnable;
    }

    public override void Build()
    {
        returnables = new List<Line>();
        Line newT = new Line();
        returnables.Add(newT);
        newT.Build();
    }


}

[System.Serializable]
[XmlType("Line")]
public class Line : ConversationBase<Reply>, IReturnable
{
    //[XmlElementAttribute("id")]
    [XmlIgnore]
    public int id { get; set; }

    [XmlElement("LineText")]
    public string lineText { get; set; }

    [XmlArray("Replies")]
    [XmlArrayItem("Reply", typeof(Reply))]
    public override List<Reply> returnables { get; set; }

    public override IReturnable GetNewReturnable()
    {
        Reply newT = new Reply();
        returnables.Add(newT);
        newT.Build();
        return newT as IReturnable;
    }

    public override void Build()
    {
        returnables = new List<Reply>();
    }
}

[System.Serializable]
[XmlType("Reply")]
public class Reply : ConversationBase<string>, IReturnable
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
