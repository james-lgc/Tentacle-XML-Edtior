using System;
using TentacleXMLEditor.Interfaces;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;

//using the TentacleConversationXML namespace shared with Unity projects
namespace TentacleConversationXML
{
    [Serializable()]
    [XmlInclude(typeof(ConversationList))]
    [XmlInclude(typeof(Conversation))]
    [XmlInclude(typeof(StoryStage))]
    [XmlInclude(typeof(ConversationStage))]
    [XmlInclude(typeof(Line))]
    [XmlInclude(typeof(Reply))]
    public abstract class ConversationBase<X> : IReturnable where X : IReturnable, new()
    {

        [XmlIgnore]
        public virtual List<X> xList { get; set; }

        [XmlIgnore]
        public virtual List<IReturnable> Returnables { get { return xList.Cast<IReturnable>().ToList(); } set { xList = value.Cast<X>().ToList(); } }

        public virtual void AddToList(IReturnable newReturnable)
        {
            Returnables.Cast<IReturnable>().ToList().Add(newReturnable);
        }

        public virtual void ReplaceContents(List<IReturnable> newContents)
        {
            xList = newContents.Cast<X>().ToList();
        }

        public void RemoveAt(int i)
        {
            xList.RemoveAt(i);
        }

        public virtual void MoveAt(int change, int index)
        {
            List<X> tempList = new List<X>();
            for (int i = 0; i < xList.Count; i++)
            {
                tempList.Add(xList[i]);
            }
            xList[index] = tempList[index + change];
            xList[index + change] = tempList[index];
        }

        public virtual IReturnable GetNewReturnable()
        {
            X newX = new X();
            xList.Add(newX);
            newX.Build();
            return newX as IReturnable;
        }

        public virtual void Build()
        {
            xList = new List<X>();
            X newX = new X();
            xList.Add(newX);
            newX.Build();
        }

    }
}

