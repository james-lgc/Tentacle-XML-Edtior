using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class WrappedReply<X> : Reply<WrappedReply<X>>, IReturnable<X>
    {
        public string WrappedReply1 { get; set; }

        public new IReturnable<X>[] Returnables { get; set; }
        /*public WrappedReply()
        {

        }*/

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
