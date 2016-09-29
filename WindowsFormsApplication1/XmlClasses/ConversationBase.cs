using System;
using System.Collections.Generic;
using TentacleXMLEditor;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//[System.Serializable]
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
    public virtual List<X> returnables { get; set; }

    [XmlIgnore]
    public virtual List<IReturnable> Returnables { get { return returnables.Cast<IReturnable>().ToList(); } set { returnables = value.Cast<X>().ToList(); } }

    public virtual void AddToList(IReturnable newReturnable)
    {
        Returnables.Cast<IReturnable>().ToList().Add(newReturnable);
    }

    public virtual void ReplaceContents(List<IReturnable> newContents)
    {
        returnables = newContents.Cast<X>().ToList();
    }

    public void RemoveAt(int i)
    {
        returnables.RemoveAt(i);
    }

    public virtual void MoveAt(int change, int index)
    {
        List<X> tempList = new List<X>();
        for (int i = 0; i < returnables.Count; i++)
        {
            tempList.Add(returnables[i]);
        }
        returnables[index] = tempList[index + change];
        returnables[index + change] = tempList[index];
        /*X selectedX = returnables[index];
        tempList.RemoveAt(index);
        returnables.Clear();
        for (int i = 0; i < tempList.Count + 1; i++)
        {
            if (i < index + change)
            {
                returnables.Add(tempList[i]);
            }
            else if (i == index + change)
            {
                returnables.Add(selectedX);
            }
            else if (i > index + change)
            {
                returnables.Add(tempList[i]);
            }
        }*/
    }

    public virtual IReturnable GetNewReturnable()
    {
        X newX = new X();
        returnables.Add(newX);
        newX.Build();
        return newX as IReturnable;
    }

    public virtual void Build()
    {
        returnables = new List<X>();
        X newX = new X();
        returnables.Add(newX);
        newX.Build();
    }

}

