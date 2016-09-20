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
        protected TentacleDoc form1;
        private Button button;
        protected SpecificContainer specificContainer;
        protected UIContainer parentContainer;
        public CollapsableTable cTable;
        public X[] xArray;
        protected X newX;
        public List<UIBox<X>> boxes;

        protected void SetUp(TentacleDoc form, SpecificContainer container, UIContainer parent, int rowCount, int columnCount, int rowNum, X[] sentXArray, string[] labelTexts, string extraText)
        { 
            cTable = new CollapsableTable(form, parent, rowCount + 1, columnCount, rowNum);
            boxes = new List<UIBox<X>>();
            form1 = form;
            specificContainer = container;
            parentContainer = parent;
            xArray = sentXArray;

            //AddButton(rowCount, extraText);

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
            AddButton(cTable.panel.RowCount - 1, extraText);
            TableSizer.AutoSize(cTable.panel);
        }

        protected void AddButton(int rowCount, string extraText)
        {
            button = new Button();
            button.Parent = cTable.panel;
            button.AutoSize = true;
            button.ForeColor = ColourManager.backGroundColour;
            button.BackColor = ColourManager.textColour;
            cTable.panel.SetRow(button, rowCount);
            cTable.panel.SetColumn(button, 0);
            cTable.panel.Controls.Add(button);
            string addText = "Add ";
            string fullText = string.Concat(addText, extraText);
            button.Text = fullText;
            button.Click += new EventHandler(this.AddRow);
        }

        protected void MoveButton()
        {
            int columnNum = cTable.panel.GetColumn(button);
            cTable.panel.SetRow(button, cTable.panel.RowCount - 1);
        }

        protected void AddLabel(int rowNum, string labelText)
        {
            Label label = new Label();
            label.BackColor = ColourManager.backGroundColour;
            label.ForeColor = ColourManager.textColour;
            label.Text = labelText;
            label.Parent = cTable.panel;
            cTable.panel.SetRow(label, rowNum);
            cTable.panel.SetColumn(label, 0);
            cTable.panel.Controls.Add(label);
        }

        protected void AddLabelWithText(string labelText)
        {
            AddLabel(cTable.panel.RowCount - 2, labelText);
        }

        protected void AddBox(UIBox<X> box)
        {
            boxes.Add(box);
        }

        public virtual void AddRow(Object sender, EventArgs e)
        {
            cTable.panel.RowCount++;
            MoveButton();
        }

        public void Expand()
        {
            TableSizer.AutoSize(cTable.panel);
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
    }
}
