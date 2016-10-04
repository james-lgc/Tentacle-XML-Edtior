using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentacleXMLEditor
{
    public class UIBoxHeading
    {
        private UIBox ParentBox { get; set; }
        private BoxInformation BoxInfo { get; set; }
        private TentacleTable HeadingTable { get; set; }
        public Control[] InputControls { get; set; }
        private int ColumnCount { get; set; }
        private bool UseHeaderTable { get; set; }

        private TentacleButton ExpandButton1 { get; set; }
        private TentacleButton RemoveButton1 { get; set; }
        private MoveButton MoveButton1 { get; set; }
        private TentaclePanel ButtonPanel { get; set; }

        public UIBoxHeading(UIBox sentBox, IReturnable sentReturnable)
        {
            SetProperties(sentBox);
            BuildColumns();
            Populate();
            BuildButtons();
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
                UseHeaderTable = true;
                HeadingTable = new TentacleTable(ParentBox.GroupBox1, BoxInfo.Fields, ColumnCount, DockStyle.Top);
                HeadingTable.SendToBack();
                for (int i = 0; i < BoxInfo.Fields; i++)
                {
                    BuildLabel(i);
                    BuildInputControl(i);
                }
            }
        }

        private void BuildColumns()
        {
            if (BoxInfo.LabelTexts != null) { ColumnCount++; ColumnCount++; }
        }

        private void BuildLabel(int i)
        {
            if (BoxInfo.LabelTexts != null)
            {
                TentacleLabel tLabel = new TentacleLabel(BoxInfo.LabelTexts[i], i, HeadingTable);
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
                        TentacleNumberBox numberBox = new TentacleNumberBox(i, HeadingTable);
                        InputControls[i] = numberBox;
                        return;
                    }
                }
            }
            TentacleTextBox textBox = new TentacleTextBox(i, HeadingTable);
            InputControls[i] = textBox;
        }

        private void BuildButtons()
        {
            switch (UseHeaderTable)
            {
                case true:
                    ButtonPanel = new TentaclePanel(HeadingTable, HeadingTable.RowCount - 1);
                    break;
                case false:
                    ButtonPanel = new TentaclePanel(ParentBox.GroupBox1);
                    break;
            }
            AddButtonsToPanel();
        }

        private void AddButtonsToPanel()
        {
            RemoveButton1 = new TentacleButton(ButtonPanel, "Remove");
            RemoveButton1.Click += new EventHandler(this.Remove);

            MoveButton1 = new MoveButton(ButtonPanel, "Move");
            MoveButton1.Menu1.Items[0].Click += (sender, e) => Move(sender, e, true);
            MoveButton1.Menu1.Items[1].Click += (sender, e) => Move(sender, e, false);

            if (BoxInfo.IsCollapsable == true)
            {
                ExpandButton1 = new TentacleButton(ButtonPanel, "Expand");
                ExpandButton1.Click += new EventHandler(this.ToggleExpansion);
                ParentBox.ChildTable.TentacleTable1.Visible = false;
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
            Cursor.Current = Cursors.WaitCursor;
            ParentBox.ParentTable.RemoveAt(ParentBox);
            Cursor.Current = Cursors.Default;
        }

        private void Move(Object sender, EventArgs e, bool isUp)
        {
            Cursor.Current = Cursors.WaitCursor;
            int change = 0;
            switch (isUp)
            {
                case true:
                    change = -1;
                    break;
                case false:
                    change = 1;
                    break;
            }
            ParentBox.ParentTable.Move(change, ParentBox);
            Cursor.Current = Cursors.Default;
        }

        private void ToggleExpansion(Object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ParentBox.GroupBox1.SuspendLayout();
            if (ParentBox.ChildTable.TentacleTable1.Visible == true)
            {
                ParentBox.ChildTable.TentacleTable1.Visible = false;
                ExpandButton1.Text = "Expand";
            }
            else
            {
                ParentBox.ChildTable.TentacleTable1.Visible = true;
                ExpandButton1.Text = "Collapse";
            }
            ParentBox.GroupBox1.ResumeLayout();
            Cursor.Current = Cursors.Default;
        }
    }
}
