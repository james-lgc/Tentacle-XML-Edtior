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
        public IReturnable[] XArray { get; set; }

        private BoxInformationContainer BoxInfos;
        private int InfoIndex;

        public UITable(GroupBox groupBox, IReturnable[] sentXArray, int columnCount, string extraText, BoxInformationContainer boxInfos, int boxIndex)
        {
            if (boxIndex == boxInfos.BoxInfos.Length - 2)
            {
                bool yesBool = true;
            }
            boxIndex++;
            InfoIndex = boxIndex;
            BoxInfos = boxInfos;
            XArray = sentXArray;
            rowCount = 1;
            if (sentXArray != null)
            {
                rowCount = sentXArray.Length + 1;
            }
            cTable = new CollapsableTable(null, groupBox, rowCount, columnCount);
            addButton = new TentacleButton(cTable, "Add" + extraText, ColourManager.addButtonColours);
            addButton.Click += new EventHandler(this.AddRow);
            if (sentXArray != null)
            {
                for (int i = 0; i < sentXArray.Length; i++)
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
                    UIBox uiBox = new UIBox(sentXArray[i], this, i, BoxInfos, InfoIndex);
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
            if (XArray == null)
            {
                XArray = new IReturnable[1];
            }

            Cursor.Current = Cursors.WaitCursor;
            cTable.panel.SuspendLayout();
            cTable.panel.RowCount++;
            MoveButton();
            TentacleLabel tLabel = new TentacleLabel("Name", cTable.panel.RowCount - 2, cTable.panel);
            UIBox uiBox = new UIBox(XArray[0].GetNewReturnable(), this, cTable.panel.RowCount -2, BoxInfos, InfoIndex);
            //form1.ResumeLayout();
            Cursor.Current = Cursors.Default;
            cTable.panel.ResumeLayout();
        }

       /* public X[] ReturnContents
        {
            get
            {
                X[] newXAraay = new X[boxes.Count];
                for (int i = 0; i < boxes.Count; i++)
                {
                    boxes[i].ReturnX();
                    //newXAraay[i] = boxes[i].thisX;
                }
                return newXAraay;
            }
        }*/

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
