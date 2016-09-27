using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.XmlClasses
{
    class ConversationBase<T> where T : IReturnable
    {
        public List<T> returnables;
        public List<IReturnable> Returnables {get; set;}

        public void AddToList(IReturnable newReturnable)
        {
            returnables.Cast<IReturnable>().ToList().Add(newReturnable);
        }
    }
}
