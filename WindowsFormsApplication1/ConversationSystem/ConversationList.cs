using System;
using TentacleXMLEditor.Interfaces;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TentacleXMLEditor.ConversationSystem
{
    [System.Serializable()]
    [XmlRoot("ConversationList")]
    public class ConversationList : ConversationBase<Conversation>, IReturnable
    {
        [XmlArray("Conversations")]
        [XmlArrayItem("Conversation", typeof(Conversation))]
        public override List<Conversation> returnables { get; set; }

        public override void Build()
        {
            if (returnables == null)
            {
                base.Build();
            }
        }
    }

    [System.Serializable]
    [XmlType("Conversation")]
    public class Conversation : ConversationBase<StoryStage>, IReturnable
    {
        [XmlAttribute("name")]
        public string name { get; set; }

        [XmlArray("StoryStages")]
        [XmlArrayItem("StoryStage", typeof(StoryStage))]
        public override List<StoryStage> returnables { get; set; }
    }

    [System.Serializable]
    [XmlType("StoryStage")]
    public class StoryStage : ConversationBase<ConversationStage>, IReturnable
    {
        [XmlIgnore]
        public int id { get; set; }

        [XmlElement("StoryThread")]
        public string storyThread { get; set; }

        [XmlElement("StageNumber")]
        public int stageNumber { get; set; }


        [XmlArray("ConversationStages")]
        [XmlArrayItem("ConversationStage", typeof(ConversationStage))]
        public override List<ConversationStage> returnables { get; set; }

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

    }

    [System.Serializable]
    [XmlType("Line")]
    public class Line : ConversationBase<Reply>, IReturnable
    {
        [XmlIgnore]
        public int id { get; set; }

        [XmlElement("LineText")]
        public string lineText { get; set; }

        [XmlArray("Replies")]
        [XmlArrayItem("Reply", typeof(Reply))]
        public override List<Reply> returnables { get; set; }

        public override void Build()
        {
            returnables = new List<Reply>();
        }
    }

    [System.Serializable]
    [XmlType("Reply")]
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
}
