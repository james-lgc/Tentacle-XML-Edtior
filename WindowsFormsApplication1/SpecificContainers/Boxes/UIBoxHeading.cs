using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class UIBoxHeading<X> : UIBox<X>
    {
        private UIBox<X> ParentBox { get; set; }
        private CollapsableTable HeadingTable { get; set; }
        public Control[] InputControls { get; set; }
        //public TentacleTextBox[] TextBoxes { get; set; }
        //public NumericUpDown[] NumberBoxes { get; set; }

        private TentacleButton ExpandButton1 { get; set; }
        private TentacleButton RemoveButton1 { get; set; }
        private TentaclePanel ButtonPanel { get; set; }

        public UIBoxHeading(UIBox<X> sentBox)
        {
            ParentBox = sentBox;

            Fields = ParentBox.Fields;
            LabelTexts = ParentBox.LabelTexts;
            IsCollapsable = ParentBox.IsCollapsable;
            NumFields = ParentBox.NumFields;

            //TextBoxes = new TentacleTextBox[Fields];
            ColumnCount = 1;
            if (Fields > 0)
            {
                if (Fields > 1 || LabelTexts != null || IsCollapsable == true)
                {
                    if (IsCollapsable == true)
                    {
                        ColumnCount++;
                    }
                    if (LabelTexts != null)
                    {
                        ColumnCount++;
                    }
                    HeadingTable = new CollapsableTable(null, ParentBox.GroupBox1, rowCount: Fields, columnCount: ColumnCount);
                    HeadingTable.panel.Dock = DockStyle.Top;
                    InputControls = new Control[Fields];
                    for (int i = 0; i < Fields; i++)
                    {
                        if (LabelTexts != null)
                        {
                            TentacleLabel tLabel = new TentacleLabel(LabelTexts[i], i, HeadingTable.panel);
                        }
                        if (NumFields == null)
                        {
                            TentacleTextBox textBox = new TentacleTextBox(i, HeadingTable.panel);
                            InputControls[i] = textBox;
                        }
                        else
                        {
                            //NumberBoxes = new TentacleNumberBox[NumFields.Length];
                            for (int j = 0; j < NumFields.Length; j++)
                            {
                                if (i == NumFields[j])
                                {
                                    TentacleNumberBox numberBox = new TentacleNumberBox(i, HeadingTable.panel);
                                    InputControls[i] = numberBox;
                                    break;
                                }
                                else if (i == NumFields.Length - 1)
                                {
                                    TentacleTextBox textBox = new TentacleTextBox(i, HeadingTable.panel);
                                    InputControls[i] = textBox;
                                    break;
                                }
                            }
                        }
                        if (i == Fields - 1 && IsCollapsable == true)
                        {
                            BuildButtons(HeadingTable, i);
                        }
                    }
                }
                else if (Fields == 1)
                {
                    TentacleTextBox TextBox1 = new TentacleTextBox(GroupBox1);
                    InputControls[0] = TextBox1;
                    //AddTextBox();
                }
            }
            else if (IsCollapsable == true)
            {
                //ParentTable = table;
                ExpandButton1 = new TentacleButton(GroupBox1, "Expand", ColourManager.expandButtonColours);
                ExpandButton1.Click += new EventHandler(this.ToggleExpansion);
                IsExpanded = false;
                ParentBox.ChildCTable.panel.Visible = false;
            }

        }

        public void BindData(string name, object obj, string prop)
        {
            //NumberBoxes[0].DataBindings.Add(name, obj, prop, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void BuildButtons(CollapsableTable sentTable, int i)
        {
            ButtonPanel = new TentaclePanel(sentTable, i);
            ButtonPanel.Margin = Padding.Empty;
            ButtonPanel.Dock = DockStyle.Left;

            RemoveButton1 = new TentacleButton(ButtonPanel, "Remove", ColourManager.removeButtonColours);

            SplitContainer SubButtonPanel = new SplitContainer();
            //spli


            /*SubButtonPanel.Parent = ButtonPanel;
            ButtonPanel.Controls.Add(SubButtonPanel);
            SubButtonPanel.Height = RemoveButton1.Height;
            SubButtonPanel.Width = RemoveButton1.Width/2;
            SubButtonPanel.Panel1MinSize = 0;
            SubButtonPanel.Panel2MinSize = 0;
            SubButtonPanel.Orientation = Orientation.Horizontal;
            SubButtonPanel.IsSplitterFixed = true;
            SubButtonPanel.SplitterDistance = SubButtonPanel.Height / 3;
            SubButtonPanel.Panel1.Padding = Padding.Empty;
            SubButtonPanel.Panel2.Padding = Padding.Empty;
            SubButtonPanel.SplitterWidth = 1;
            SubButtonPanel.Padding = Padding.Empty;



            TentacleButton upButton = new TentacleButton(SubButtonPanel.Panel1, "Up", ColourManager.moveButtonColours);
            TentacleButton downButton = new TentacleButton(SubButtonPanel.Panel2, "Down", ColourManager.moveButtonColours);
            upButton.AutoSize = false;
            upButton.Dock = DockStyle.Fill;
            upButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            upButton.MinimumSize = System.Drawing.Size.Empty;
            //upButton.Height = RemoveButton1.Height/2;
            //upButton.
            downButton.Dock = DockStyle.Fill;
            downButton.AutoSize = false;
            downButton.MinimumSize = System.Drawing.Size.Empty;
            downButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            downButton.Height = RemoveButton1.Height / 2;*/

            ExpandButton1 = new TentacleButton(ButtonPanel, "Expand", ColourManager.expandButtonColours);
            ExpandButton1.Click += new EventHandler(this.ToggleExpansion);
            IsExpanded = false;
            ParentBox.ChildCTable.panel.Visible = false;

            //RemoveButton1.Click += new EventHandler(this.ToggleExpansion);
        }

        private void Remove()
        {

        }

        private void ToggleExpansion(Object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ParentBox.GroupBox1.SuspendLayout();
            if (IsExpanded == true)
            {
                IsExpanded = false;
                ParentBox.ChildCTable.panel.Visible = false;
                ExpandButton1.Text = "Expand";
            }
            else
            {
                IsExpanded = true;
                ParentBox.ChildCTable.panel.Visible = true;
                ExpandButton1.Text = "Collapse";
            }
            ParentBox.GroupBox1.ResumeLayout();
            Cursor.Current = Cursors.Default;
        }
    }
}
