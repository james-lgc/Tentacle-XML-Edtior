using System;

namespace TentacleXMLEditor.Structure
{
    public struct BoxInformation
    {
        public string BoxLabel { get; }
        public int Fields { get; }
        public int ColumnCount { get; }
        public int[] NumFields { get; }
        public string[] LabelTexts { get; }
        public bool IsCollapsable { get; }
        public string ExtraText { get; }
        public DataBindingInfo[] BindingInfo { get; }
        public bool IsScrollable { get; }

        public BoxInformation(string boxLabel = null, int fields = 0, int columnCount = 1, int[] numFields = null, string[] labelTexts = null, bool isCollapsable = true, string extraText = null, DataBindingInfo[] bindingInfo = null, bool isScrollable = false)
        {
            BoxLabel = boxLabel;
            Fields = fields;
            ColumnCount = columnCount;
            NumFields = numFields;
            LabelTexts = labelTexts;
            IsCollapsable = isCollapsable;
            ExtraText = extraText;
            BindingInfo = bindingInfo;
            IsScrollable = isScrollable;
        }
    }
}


