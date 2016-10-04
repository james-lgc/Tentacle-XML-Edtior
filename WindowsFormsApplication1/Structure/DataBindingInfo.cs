using System;

namespace TentacleXMLEditor.Structure
{
    public struct DataBindingInfo
    {
        private string bindingProperty;
        private bool isText;
        public string BindingProperty { get { return bindingProperty; } }
        public bool IsText { get { return isText; } }

        public DataBindingInfo(string sentBind, bool sentIsText)
        {
            bindingProperty = sentBind;
            isText = sentIsText;
        }
    }
}
