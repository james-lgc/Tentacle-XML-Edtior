﻿using System;
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

        private TentacleButton addButton { get; set; }
        protected UIContainer parentContainer;
        public CollapsableTable cTable;
        public IReturnable[] XArray { get; set; }

        private BoxInformationContainer BoxInfos;
        private int InfoIndex;

        public UITable(GroupBox groupBox, IReturnable[] sentXArray, int columnCount, string extraText, BoxInformationContainer boxInfos, int boxIndex)
        {
            cTable = new CollapsableTable(null, groupBox, sentXArray.Length + 1, columnCount);
            //boxes = new List<SpecificContainer<X>>();
            boxIndex++;
            InfoIndex = boxIndex;
            BoxInfos = boxInfos;
            XArray = sentXArray;
            addButton = new TentacleButton(cTable, "Add" + extraText, ColourManager.addButtonColours);
            addButton.Click += new EventHandler(this.AddRow);
        }

        public void SetUp<sentX>(IReturnable[] sentXArray) where sentX : IReturnable, new()
        {
            X = typeof(sentX);
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

        protected void MoveButton()
        {
            //int columnNum = cTable.panel.GetColumn(addButton);
            //cTable.panel.SetRow(addButton, cTable.panel.RowCount - 1);
        }

        public virtual void AddRow(Object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //form1.SuspendLayout();
            //cTable.panel.SuspendLayout();
            cTable.panel.RowCount++;
            MoveButton();
            TentacleLabel tLabel = new TentacleLabel("Name", cTable.panel.RowCount - 2, cTable.panel);
            //Type X = XArray.
            Type X = XArray[0].GetType();
            typeof(X) newX = new X();
            UIBox uiBox = new UIBox(new typeof(XArray[0].GetType()(), this, i, boxInfos, boxIndex);
            //form1.ResumeLayout();
            Cursor.Current = Cursors.Default;
            //cTable.panel.ResumeLayout();
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
