using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class UITable
    {
        protected string[] labelTexts { get; set; }
        private int rowCount;
        private TentacleButton addButton { get; set; }
        protected UIContainer parentContainer;
        public CollapsableTable cTable;
        public IReturnable SentX { get; set; }
        public IReturnable[] YArray { get; set; }
        public List<UIBox> Boxes { get; set; }

        private BoxInformationContainer BoxInfos;
        private int InfoIndex;

        public UITable(GroupBox groupBox, IReturnable sentX, int columnCount, string extraText, BoxInformationContainer boxInfos, int boxIndex)
        {
            SentX = sentX;
            try
            {
                YArray = sentX.Returnables as IReturnable[];
            }
            catch (NullReferenceException e)
            {

            }
            if (boxIndex == boxInfos.BoxInfos.Length - 2)
            {
                bool yesBool = true;
            }
            boxIndex++;
            InfoIndex = boxIndex;
            BoxInfos = boxInfos;
            rowCount = 1;
            if (YArray != null)
            {
                rowCount = YArray.Length + 1;
            }
            cTable = new CollapsableTable(null, groupBox, rowCount, columnCount);
            addButton = new TentacleButton(cTable, "Add" + extraText, ColourManager.addButtonColours);
            addButton.Click += new EventHandler(this.AddRow);
            Boxes = new List<UIBox>();
            if (YArray != null)
            {
                for (int i = 0; i < YArray.Length; i++)
                {
                    if (labelTexts != null)
                    {
                        Label label = new Label();
                        int j = 0;
                        if (labelTexts.Length > 1)
                        {
                            j = i;
                        }
                        TentacleLabel tLabel = new TentacleLabel(labelTexts[j], i, cTable.panel);
                    }
                    UIBox uiBox = new UIBox(YArray[i], this, i, BoxInfos, InfoIndex);
                    Boxes.Add(uiBox);
                }
            }
        }

        protected void MoveButton()
        {
            int columnNum = cTable.panel.GetColumn(addButton);
            cTable.panel.SetRow(addButton, cTable.panel.RowCount - 1);
        }

        public virtual void AddRow(Object sender, EventArgs e)
        {
            IReturnable NewX = SentX.GetNewReturnable();
            Cursor.Current = Cursors.WaitCursor;
            cTable.panel.SuspendLayout();
            cTable.panel.RowCount++;
            MoveButton();
            //TentacleLabel tLabel = new TentacleLabel("Name", cTable.panel.RowCount - 2, cTable.panel);
            UIBox uiBox = new UIBox(NewX, this, cTable.panel.RowCount -2, BoxInfos, InfoIndex);
            //form1.ResumeLayout();
            Cursor.Current = Cursors.Default;
            cTable.panel.ResumeLayout();
        }

        public IReturnable[] ReturnContents()
        {
             {
                IReturnable[] newXAraay = new IReturnable[Boxes.Count];
                for (int i = 0; i < Boxes.Count; i++)
                {
                    newXAraay[i] = Boxes[i].ReturnX();
                }
                return newXAraay;
            }
        }

        private void Remove()
        {

        }

        protected void Step()
        {
            try
            {
                //form1.loadingPanel.IncreaseProgress();
            }
            catch (NullReferenceException e)
            {

            }
        }
    }
}
