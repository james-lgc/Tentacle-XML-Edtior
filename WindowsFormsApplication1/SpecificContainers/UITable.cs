using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentacleXMLEditor
{
    public class UITable
    {
        protected string[] labelTexts { get; set; }
        private int RowCount { get; set; }
        private TentacleButton AddButton { get; set; }
        protected UIBox ParentBox;
        public CollapsableTable TentacleTable1 { get; private set; }
        public List<UIBox> Boxes { get; set; }

        private BoxInformationContainer BoxInfos { get; set; }
        private int InfoIndex { get; set; }

        public UITable(UIBox parentBox, IReturnable sentX, List<IReturnable> yArray, BoxInformationContainer boxInfos, int boxIndex)
        {
            SetProperties(parentBox, boxIndex, boxInfos, yArray);
            Populate(yArray);
        }

        private void SetProperties(UIBox parentBox, int boxIndex, BoxInformationContainer boxInfos, List<IReturnable> yArray)
        {
            ParentBox = parentBox;
            boxIndex++;
            RowCount = 1;
            InfoIndex = boxIndex;
            BoxInfos = boxInfos;
            Boxes = new List<UIBox>();
            if (yArray != null)
            {
                RowCount = yArray.Count + 1;
            }
        }

        private void Populate(List<IReturnable> yArray)
        {
            TentacleTable1 = new CollapsableTable(ParentBox.GroupBox1, RowCount, ParentBox.BoxInfo.ColumnCount, DockStyle.Fill);
            AddButton = new TentacleButton(TentacleTable1, "Add" + ParentBox.BoxInfo.ExtraText);
            AddButton.Click += new EventHandler(this.AddRow);
            if (yArray != null)
            {
                for (int i = 0; i < yArray.Count; i++)
                {
                    BuildLabels(i);
                    UIBox uiBox = new UIBox(yArray[i], this, i, BoxInfos, InfoIndex);
                    Boxes.Add(uiBox);
                }
            }
        }

        private void BuildLabels(int i)
        {
            if (labelTexts != null)
            {
                Label label = new Label();
                int j = 0;
                if (labelTexts.Length > 1)
                {
                    j = i;
                }
                TentacleLabel tLabel = new TentacleLabel(labelTexts[j], i, TentacleTable1.panel);
            }
        }

        protected void MoveButton()
        {
            int columnNum = TentacleTable1.panel.GetColumn(AddButton);
            TentacleTable1.panel.SetRow(AddButton, TentacleTable1.panel.RowCount - 1);
        }

        public virtual void AddRow(Object sender, EventArgs e)
        {
            IReturnable NewX = ParentBox.ThisX.GetNewReturnable();
            ParentBox.ThisX.AddToList(NewX);
            Cursor.Current = Cursors.WaitCursor;
            TentacleTable1.panel.SuspendLayout();
            TentacleTable1.panel.RowCount++;
            MoveButton();
            UIBox uiBox = new UIBox(NewX, this, TentacleTable1.panel.RowCount -2, BoxInfos, InfoIndex);
            Boxes.Add(uiBox);
            Cursor.Current = Cursors.Default;
            TentacleTable1.panel.ResumeLayout();
        }
    }
}
