using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    [System.Serializable]
    public class WrappedReply : IReturnable
    {
        public string Reply1 { get; set; }

        public IReturnable GetNewReturnable()
        {
            return null;
        }

        public void Set(IReturnable[] sentReturnables)
        {

        }
        //[XmlIgnore]
        public IReturnable[] Returnables { get { return null; } set { } }

        public void Build(string replyText)
        {
            Reply1 = replyText;
        }

        /*public WrappedReply[] GetReplies(string[] sentReplies)
        {
            WrappedReply[] wrappedReplies = new WrappedReply[sentReplies.Length];
            for (int i = 0; i < sentReplies.Length; i++)
            {
                wrappedReplies[i].WrappedReply1 = sentReplies[i];
            }
            return wrappedReplies;
        }*/
    }
}
