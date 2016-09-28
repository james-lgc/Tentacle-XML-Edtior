using System;
using System.Collections.Generic;
using WindowsFormsApplication1;
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
public abstract class ConversationBase<X> : IReturnable
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

    public virtual IReturnable GetNewReturnable()
    {
        return null;
    }

    public virtual void Build()
    {

    }

}

