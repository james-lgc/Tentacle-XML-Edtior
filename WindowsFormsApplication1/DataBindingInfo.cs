using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public struct DataBindingInfo
    {
        public string bindingProperty { get; }
        public bool isText { get; }

        public DataBindingInfo(string sentBind, bool sentIsText)
        {
            bindingProperty = sentBind;
            isText = sentIsText;
        }
    }
}
