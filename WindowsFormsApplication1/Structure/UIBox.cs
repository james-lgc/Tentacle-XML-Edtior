﻿using System;
using TentacleConversationXML;
using TentacleXMLEditor.Interfaces;
using TentacleXMLEditor.Processors;
using TentacleXMLEditor.UIElements;

namespace TentacleXMLEditor.Structure
{
    public class UIBox
    {
        public static TentacleDoc TentacleDoc1 { get; set; }
        public UITable ParentTable { get; set; }
        public UITable ChildTable { get; set; }
        public UIBoxHeading BoxHeading { get; set; }
        public TentacleGroupBox GroupBox1 { get; set; }

        public IReturnable ThisX { get; set; }
        protected bool IsExpanded { get; set; }

        private BoxInformation BoxInformation1 { get; set; }
        private BoxInformationContainer BoxInfos { get; set; }
        public BoxInformation BoxInfo { get; private set; }
        private int BoxIndex { get; set; }


        public UIBox(IReturnable sentX, UITable parentTable, int rowNum, BoxInformationContainer boxInfos, int boxIndex, TentacleDoc tDoc = null)
        {
            SetProperties(sentX, parentTable, boxInfos, boxIndex, tDoc);
            TentacleDoc1.IncreaseLoadingProgress();
            ParentGroupBox(parentTable, rowNum, tDoc);
            Populate(sentX);
            GroupBox1.Visible = true;
        }

        private void SetProperties(IReturnable sentX, UITable parentTable, BoxInformationContainer boxInfos, int boxIndex, TentacleDoc tDoc = null)
        {
            if (tDoc != null) { TentacleDoc1 = tDoc; }
            ThisX = sentX;
            ParentTable = parentTable;
            BoxIndex = boxIndex;
            BoxInfos = boxInfos;
            BoxInfo = boxInfos.BoxInfos[boxIndex];
            GroupBox1 = new TentacleGroupBox(BoxInfo.BoxLabel);
        }

        private void ParentGroupBox(UITable parentTable, int rowNum, TentacleDoc tDoc)
        {
            if (ParentTable != null)
            {
                Parenter.Parent(GroupBox1, parentTable.TentacleTable1, rowNum, ParentTable.TentacleTable1.ColumnCount - 1);
            }
            else if (tDoc != null)
            {
                Parenter.Parent(GroupBox1, tDoc);
            }
        }

        private void Populate(IReturnable sentX)
        {
            if (BoxIndex == 0)
            {
                ChildTable = new UITable(this, sentX as IReturnable, sentX.Returnables, BoxInfos, BoxIndex);
            }
            else if (BoxIndex < BoxInfos.BoxInfos.Length - 1)
            {
                ChildTable = new UITable(this, sentX as IReturnable, sentX.Returnables, BoxInfos, BoxIndex);
                BoxHeading = new UIBoxHeading(this, sentX);
            }
            else { BoxHeading = new UIBoxHeading(this, sentX); }
        }
    }
}
