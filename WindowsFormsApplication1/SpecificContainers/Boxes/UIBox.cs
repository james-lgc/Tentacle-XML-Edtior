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
        private BoxInformation BoxInformation1 { get; set; }

        public IReturnable ThisX { get; set; }
        public GroupBox GroupBox1 { get; set; }
        public UIBoxHeading BoxHeading { get; set; }

        public UITable ParentTable { get; set; }
        protected bool IsExpanded { get; set; }

        public BoxInformation BoxInfo { get; private set; }

        

        public UITable ChildTable { get; set; }


        public UIBox(IReturnable sentX, UITable parentTable, int rowNum, BoxInformationContainer boxInfos, int boxIndex, TentacleDoc tDoc = null)
        {
            ThisX = sentX;
            ParentTable = parentTable;
            if (boxIndex < boxInfos.BoxInfos.Length)
            {
                BoxInfo = boxInfos.BoxInfos[boxIndex];
            }
            else { return; }

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
            IReturnable[] yArray = ThisX.Returnables as IReturnable[];
            if (yArray != null)
            {
                ChildTable = new UITable(GroupBox1, yArray as IReturnable[], BoxInfo.ColumnCount, BoxInfo.ExtraText, boxInfos, boxIndex);
                BoxHeading = new UIBoxHeading(this);
            }
        }

        public void SaveContents()
        {

        }
    }
}
