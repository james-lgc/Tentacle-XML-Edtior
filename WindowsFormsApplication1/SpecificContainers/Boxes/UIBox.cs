using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public abstract class UIBox<X> : SpecificContainer
    {
        public X thisX { get; set; }
        public GroupBox GroupBox1 { get; set; }
        public TextBox[] TextBoxes { get; set; }
        public NumericUpDown[] NumberBoxes { get; set; }
        private TentacleButton ExpandButton1 { get; set; }
        private TentacleButton RemoveButton1 { get; set; }
        private TentaclePanel ButtonPanel { get; set; }
        private TentaclePanel SubButtonPanel { get; set; }
        public int ColumnCount { get; set; }
        public CollapsableTable ParentTable { get; set; }
        private bool IsExpanded { get; set; }

        protected void SetUp(X sentX, TentacleDoc form, TableLayoutPanel parentPanel, int rowNum, string labelText)
        {
            thisX = sentX;

            GroupBox1 = new GroupBox();
            GroupBox1.BackColor = ColourManager.backGroundColour2;
            GroupBox1.ForeColor = ColourManager.textColour;
            GroupBox1.AutoSize = true;
            GroupBox1.Text = labelText;
            GroupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            GroupBox1.Dock = DockStyle.Fill;
            if (parentPanel != null)
            {
                GroupBox1.Parent = parentPanel;
                parentPanel.SetCellPosition(GroupBox1, new TableLayoutPanelCellPosition(rowNum, parentPanel.ColumnCount - 1));
                parentPanel.Controls.Add(GroupBox1);
            }
            else
            {
                form.Controls.Add(GroupBox1);
            }
        }

        public void SaveContents()
        {

        }

        public virtual X ReturnX()
        {
            return thisX;
        }

        public void AddHeading(TentacleDoc form, CollapsableTable table, int fields, string[] labelTexts, bool isCollapsable, int[] numFields = null)
        {
            TextBoxes = new TentacleTextBox[fields];
            ColumnCount = 1;
            if (fields > 0)
            {
                if (fields > 1 || labelTexts != null || isCollapsable == true)
                {
                    if (isCollapsable == true)
                    {
                        ColumnCount++;
                    }
                    if (labelTexts != null)
                    {
                        ColumnCount++;
                    }
                    CollapsableTable subTable = new CollapsableTable(form, GroupBox1, rowCount: fields, columnCount: ColumnCount);
                    subTable.panel.Dock = DockStyle.Top;
                    ParentTable = table;
                    for (int i = 0; i < fields; i++)
                    {
                        if (labelTexts != null)
                        {
                            TentacleLabel tLabel = new TentacleLabel(labelTexts[i], i, subTable.panel);
                        }
                        if (numFields == null)
                        {
                            TentacleTextBox textBox = new TentacleTextBox(i, subTable.panel);
                            TextBoxes[i] = textBox;
                        }
                        else
                        {
                            NumberBoxes = new TentacleNumberBox[numFields.Length];
                            for (int j = 0; j < numFields.Length; j++)
                            {
                                if (i == numFields[j])
                                {
                                    TentacleNumberBox numberBox = new TentacleNumberBox(i, subTable.panel);
                                    NumberBoxes[j] = numberBox;
                                }
                                else
                                {
                                    TentacleTextBox textBox = new TentacleTextBox(i, subTable.panel);
                                    TextBoxes[i] = textBox;
                                }
                            }
                        }
                        if (i == fields - 1 && isCollapsable == true)
                        {
                            BuildButtons(subTable, i);
                        }
                    }
                }
                else if (fields == 1)
                {
                    TentacleTextBox TextBox1 = new TentacleTextBox(GroupBox1);
                    TextBoxes[0] = TextBox1;
                    //AddTextBox();
                }
            }
            else if (isCollapsable == true)
            {
                ParentTable = table;
                ExpandButton1 = new TentacleButton(GroupBox1, "Expand", ColourManager.expandButtonColours);
                ExpandButton1.Click += new EventHandler(this.ToggleExpansion);
                IsExpanded = false;
                ParentTable.panel.Visible = false;
            }

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
            ParentTable.panel.Visible = false;

            //RemoveButton1.Click += new EventHandler(this.ToggleExpansion);
        }

        private void Remove()
        {

        }

        private void ToggleExpansion(Object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            GroupBox1.SuspendLayout();
            if (IsExpanded == true)
            {
                IsExpanded = false;
                ParentTable.panel.Visible = false;
                ExpandButton1.Text = "Expand";
            }
            else
            {
                IsExpanded = true;
                ParentTable.panel.Visible = true;
                ExpandButton1.Text = "Collapse";
            }
            GroupBox1.ResumeLayout();
            Cursor.Current = Cursors.Default;
        }

        /*public override void SetChildControls(CollapsableTable cTable)
        {
            cTable.panel.Parent = GroupBox1;
            GroupBox1.Controls.Add(cTable.panel);
        }*/
    }
}
