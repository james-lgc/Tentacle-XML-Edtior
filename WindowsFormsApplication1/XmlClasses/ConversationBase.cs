using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    [System.Serializable]
    public abstract class ConversationBase
    {
        protected virtual List<T> returnables { get; set; }
        public virtual List<IReturnable> Returnables { get { return returnables.Cast<IReturnable>().ToList(); } set { returnables = value.Cast<T>().ToList(); } }

        public virtual void AddToList(IReturnable newReturnable)
        {
            returnables.Cast<IReturnable>().ToList().Add(newReturnable);
        }

        public virtual void ReplaceContents(List<IReturnable> newContents)
        {
            returnables = newContents.Cast<T>().ToList();
        }

        public virtual IReturnable GetNewReturnable()
        {
            T newT = new T();
            returnables.Add(newT);
            newT.Build();
            return newT as IReturnable;
        }

        public virtual void Build()
        {
            T newT = new T();
            returnables.Add(newT);
            newT.Build();
        }
    }
}
