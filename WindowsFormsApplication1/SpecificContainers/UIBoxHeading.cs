using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class UIBoxHeading
    {
        private UIBox ParentBox { get; set; }
        private BoxInformation BoxInfo { get; set; }
        private CollapsableTable HeadingTable { get; set; }
        public Control[] InputControls { get; set; }
        private int ColumnCount { get; set; }
        private bool UseHeaderTable { get; set; }

        private TentacleButton ExpandButton1 { get; set; }
        private TentacleButton RemoveButton1 { get; set; }
        private TentaclePanel ButtonPanel { get; set; }

        public UIBoxHeading(UIBox sentBox, IReturnable sentReturnable)
        {
            SetProperties(sentBox);
            BuildColumns();
            Populate();
            BuildButtons(HeadingTable);
            BindData(sentReturnable);
        }

        private void SetProperties(UIBox sentBox)
        {
            ParentBox = sentBox;
            BoxInfo = ParentBox.BoxInfo;
            InputControls = new Control[BoxInfo.Fields];
            ColumnCount = 1;
            UseHeaderTable = false;
        }

        private void Populate()
        {
            if (BoxInfo.Fields > 0)
            {
                HeadingTable = new CollapsableTable(ParentBox.GroupBox1, BoxInfo.Fields, ColumnCount, DockStyle.Top);
                for (int i = 0; i < BoxInfo.Fields; i++)
                {
                    BuildLabel(i);
                    BuildInputControl(i);
                }
            }
        }

        private void BuildColumns()
        {
            if (BoxInfo.IsCollapsable == true) { ColumnCount++; }
            if (BoxInfo.LabelTexts != null) { ColumnCount++; }
        }

        private void BuildLabel(int i)
        {
            if (BoxInfo.LabelTexts != null)
            {
                TentacleLabel tLabel = new TentacleLabel(BoxInfo.LabelTexts[i], i, HeadingTable.panel);
            }
        }

        private void BuildInputControl(int i)
        {
            if (BoxInfo.NumFields != null)
            {
                for (int j = 0; j < BoxInfo.NumFields.Length; j++)
                {
                    if (i == BoxInfo.NumFields[j])
                    {
                        TentacleNumberBox numberBox = new TentacleNumberBox(i, HeadingTable.panel);
                        InputControls[i] = numberBox;
                        return;
                    }
                }
            }
            TentacleTextBox textBox = new TentacleTextBox(i, HeadingTable.panel);
            InputControls[i] = textBox;
        }

        private void BuildButtons(CollapsableTable sentTable)
        {
            switch (UseHeaderTable)
            {
                case true:
                    ButtonPanel = new TentaclePanel(sentTable, sentTable.panel.RowCount - 1);
                    break;
                case false:
                    ButtonPanel = new TentaclePanel(ParentBox.GroupBox1);
                    break;
            }
            AddButtonsToPanel();
        }

        private void AddButtonsToPanel()
        {
            RemoveButton1 = new TentacleButton(ButtonPanel, "Remove", ColourManager.removeButtonColours);
            RemoveButton1.Click += new EventHandler(this.Remove);

            if (BoxInfo.IsCollapsable == true)
            {
                ExpandButton1 = new TentacleButton(ButtonPanel, "Expand", ColourManager.expandButtonColours);
                ExpandButton1.Click += new EventHandler(this.ToggleExpansion);
                ParentBox.ChildTable.TentacleTable1.panel.Visible = false;
            }
        }

        public void BindData(IReturnable ThisX)
        {
            if (InputControls != null && InputControls.Length > 0 && ParentBox.BoxInfo.BindingInfo != null)
            {
                for (int i = 0; i < InputControls.Length; i++)
                {
                    switch (BoxInfo.BindingInfo[i].IsText)
                    {
                        case true:
                            InputControls[i].DataBindings.Add("Text", ThisX, ParentBox.BoxInfo.BindingInfo[i].BindingProperty, false, DataSourceUpdateMode.OnPropertyChanged);
                            break;
                        case false:
                            InputControls[i].DataBindings.Add("Value", ThisX, ParentBox.BoxInfo.BindingInfo[i].BindingProperty, false, DataSourceUpdateMode.OnPropertyChanged);
                            break;
                    }
                }
            }
        }

        private void Remove(object sender, EventArgs e)
        {

        }

        private void ToggleExpansion(Object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ParentBox.GroupBox1.SuspendLayout();
            if (ParentBox.ChildTable.TentacleTable1.panel.Visible == true)
            {
                ParentBox.ChildTable.TentacleTable1.panel.Visible = false;
                ExpandButton1.Text = "Expand";
            }
            else
            {
                ParentBox.ChildTable.TentacleTable1.panel.Visible = true;
                ExpandButton1.Text = "Collapse";
            }
            ParentBox.GroupBox1.ResumeLayout();
            Cursor.Current = Cursors.Default;
        }
    }
}
