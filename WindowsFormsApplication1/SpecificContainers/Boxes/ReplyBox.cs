using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class RepliesBox : UIBox<WrappedReply>
    {
        public RepliesBox(TentacleDoc form, ReplyTable replyTable, int rowNum, WrappedReply reply)
        {
            Fields = 1;
            LabelTexts = new string[] { "Reply" };
            IsCollapsable = false;
            NumFields = null;

            base.SetUp(reply, form, replyTable, rowNum, null);
            //stringWrapper stringWrapper = new StringWrapper();
            //stringWrapper.wrappedString = reply;
            BoxHeading = new UIBoxHeading<WrappedReply>(this);
            BoxHeading.InputControls[0].DataBindings.Add("Text", thisX, "WrappedReply1", false, DataSourceUpdateMode.OnPropertyChanged);
            thisX = reply;
        }

        public override WrappedReply ReturnX()
        {
            return base.ReturnX();
        }
    }
}
