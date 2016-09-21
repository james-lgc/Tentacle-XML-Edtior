using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class UITable<X> : SpecificContainer<X>
    {
        protected string[] labelTexts { get; set; }

        protected TentacleDoc form1;
        private TentacleButton addButton { get; set; }
        //protected UIBox<X> specificContainer;
        protected UIContainer parentContainer;
        public CollapsableTable cTable;
        public X[] xArray;
        protected X NewX { get; set; }
        public List<SpecificContainer<X>> boxes;

        public UITable(GroupBox groupBox, int rowCount, int columnCount, X[] sentXArray, string extraText)
        {

        }

        protected void SetUp(TentacleDoc form, GroupBox groupBox, int rowCount, int columnCount, X[] sentXArray, string extraText)
        { 
            cTable = new CollapsableTable(form, groupBox, rowCount + 1, columnCount);
            boxes = new List<SpecificContainer<X>>();
            form1 = form;
            //specificContainer = container;
            //parentContainer = parent;
            xArray = sentXArray;

            if (labelTexts != null)
            {
                for (int i = 0; i < sentXArray.Length; i++)
                {
                    Label label = new Label();
                    int j = 0;
                    if (labelTexts.Length > 1)
                    {
                        j = i;
                    }
                    TentacleLabel tLabel = new TentacleLabel(labelTexts[j], i, cTable.panel);
                }
                    
            }
            addButton = new TentacleButton(cTable, "Add" + extraText, ColourManager.addButtonColours);
            addButton.Click += new EventHandler(this.AddRow);
            TableSizer.AutoSize(cTable.panel);
        }

        protected void MoveButton()
        {
            int columnNum = cTable.panel.GetColumn(addButton);
            cTable.panel.SetRow(addButton, cTable.panel.RowCount - 1);
        }

        protected void AddBox<Y>(SpecificContainer<X> box) where Y : X
        {
            boxes.Add(box);
            Step();
        }

        public virtual void AddRow(Object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            form1.SuspendLayout();
            //cTable.panel.SuspendLayout();
            cTable.panel.RowCount++;
            MoveButton();
            //TentacleLabel tLabel = new TentacleLabel("Name", cTable.panel.RowCount - 2, cTable.panel);
            form1.ResumeLayout();
            Cursor.Current = Cursors.Default;
            //cTable.panel.ResumeLayout();
        }

        public X[] ReturnContents
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
        }

        private void Remove()
        {

        }

        protected void Step()
        {
            try
            {
                form1.loadingPanel.IncreaseProgress();
            }
            catch (NullReferenceException e)
            {

            }
        }
    }
}
