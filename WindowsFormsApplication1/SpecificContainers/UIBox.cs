using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class UIBox
    {
        public static TentacleDoc TentacleDoc1 { get; set; }
        private BoxInformation BoxInformation1 { get; set; }

        public IReturnable ThisX { get; set; }
        List<IReturnable> yArray;
        public GroupBox GroupBox1 { get; set; }
        public UIBoxHeading BoxHeading { get; set; }

        public UITable ParentTable { get; set; }
        protected bool IsExpanded { get; set; }

        private BoxInformationContainer BoxInfos { get; set; }
        private int BoxIndex { get; set; }
        public BoxInformation BoxInfo { get; private set; }

        

        public UITable ChildTable { get; set; }


        public UIBox(IReturnable sentX, UITable parentTable, int rowNum, BoxInformationContainer boxInfos, int boxIndex, TentacleDoc tDoc = null)
        {
            if (tDoc != null)
            {
                TentacleDoc1 = tDoc;
            }
            TentacleDoc1.IncreaseLoadingProgress();
            ThisX = sentX;
            ParentTable = parentTable;
            BoxIndex = boxIndex;
            if (boxIndex < boxInfos.BoxInfos.Length)
            {
                BoxInfo = boxInfos.BoxInfos[boxIndex];
            }
            else { return; }
            if (boxIndex == boxInfos.BoxInfos.Length -1)
            {
                bool yesBool = true;
            }

            GroupBox1 = new GroupBox();
            GroupBox1.BackColor = ColourManager.backGroundColour2;
            GroupBox1.ForeColor = ColourManager.textColour;
            GroupBox1.AutoSize = true;
            GroupBox1.Text = BoxInfo.BoxLabel;
            GroupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            GroupBox1.Dock = DockStyle.Fill;
            if (ParentTable != null)
            {
                GroupBox1.Parent = ParentTable.cTable.panel;
                ParentTable.cTable.panel.SetCellPosition(GroupBox1, new TableLayoutPanelCellPosition(rowNum, ParentTable.cTable.panel.ColumnCount - 1));
                ParentTable.cTable.panel.Controls.Add(GroupBox1);
            }
            else if (tDoc != null)
            {
                GroupBox1.Parent = tDoc;
                GroupBox1.Dock = DockStyle.Fill;
                tDoc.Controls.Add(GroupBox1);
            }
            if (boxIndex < boxInfos.BoxInfos.Length - 1)
            {
                ChildTable = new UITable(GroupBox1, ThisX as IReturnable, BoxInfo.ColumnCount, BoxInfo.ExtraText, boxInfos, boxIndex);
                BoxHeading = new UIBoxHeading(this);
            }
            else
            {
                BoxHeading = new UIBoxHeading(this);
            }  
        }

        public void SaveContents()
        {

        }

        public void ReturnX()
        {
            if (ChildTable != null)
            {
                ChildTable.ReturnContents(ThisX.Returnables);
                ThisX.ReplaceContents(ChildTable.YArray);
            }
        }
    }
}
