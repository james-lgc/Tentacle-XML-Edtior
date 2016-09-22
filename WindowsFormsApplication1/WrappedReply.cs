using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class WrappedReply : Reply, IReturnable<ReplyString>
    {
        public ReplyString[] WrappedReply1 { get; set; }

        public new IReturnable<ReplyString>[] Returnables { get { return WrappedReply1; } set { } }
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
