using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public abstract class UITable<X> : SpecificContainer
    {
        protected string[] labelTexts { get; set; }

        protected TentacleDoc form1;
        private TentacleButton addButton { get; set; }
        protected SpecificContainer specificContainer;
        protected UIContainer parentContainer;
        public CollapsableTable cTable;
        public X[] xArray;
        protected X newX;
        public List<UIBox<X>> boxes;

        protected void SetUp(TentacleDoc form, SpecificContainer container, UIContainer parent, int rowCount, int columnCount, X[] sentXArray, string extraText)
        { 
            cTable = new CollapsableTable(form, parent, rowCount + 1, columnCount);
            boxes = new List<UIBox<X>>();
            form1 = form;
            specificContainer = container;
            parentContainer = parent;
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

        protected void AddBox(UIBox<X> box)
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
            //entacleLabel tLabel = new TentacleLabel("Name", cTable.panel.RowCount - 2, cTable.panel);
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
                    newXAraay[i] = boxes[i].thisX;
                }
                return newXAraay;
            }
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
