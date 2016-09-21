using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class HeadedFixedContainer : UIContainer
    {
        private TentacleButton ExpandButton1 { get; set; }
        private TentacleButton RemoveButton1 { get; set; }
        private TentaclePanel ButtonPanel { get; set; }
        private TentaclePanel SubButtonPanel { get; set; }
        private int columnCount;
        public GroupBox groupBox;
        public TentacleTextBox[] TextBoxes { get; set; }
        public TentacleNumberBox[] numberBoxes { get; set; }
        //public NumericUpDown[] numUpDowns;
        public IExpandable expandable;
        private CollapsableTable cTable;
        private bool isExpanded;

        public HeadedFixedContainer(TentacleDoc form, TableLayoutPanel parentPanel, int rowNum, string labelText)
        {
            groupBox = new GroupBox();
            groupBox.BackColor = ColourManager.backGroundColour2;
            groupBox.ForeColor = ColourManager.textColour;
            groupBox.AutoSize = true;
            groupBox.Text = labelText;
            groupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox.Dock = DockStyle.Fill;
            if (parentPanel != null)
            {
                groupBox.Parent = parentPanel;
                parentPanel.SetCellPosition(groupBox, new TableLayoutPanelCellPosition(rowNum, parentPanel.ColumnCount - 1));
                parentPanel.Controls.Add(groupBox);
            }
            else
            {
                form.Controls.Add(groupBox);
            }
        }

        public void AddHeading(TentacleDoc form, CollapsableTable table, int fields, string[] labelTexts, bool isCollapsable, int[] numFields = null)
        {
            TextBoxes = new TentacleTextBox[fields];
            columnCount = 1;
            if (fields > 0)
            {
                if (fields > 1 || labelTexts != null || isCollapsable == true)
                {
                    if (isCollapsable == true)
                    {
                        columnCount++;
                    }
                    if (labelTexts != null)
                    {
                        columnCount++;
                    }
                    CollapsableTable subTable = new CollapsableTable(form, this, rowCount: fields, columnCount: columnCount);
                    subTable.panel.Dock = DockStyle.Top;
                    cTable = table;
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
                            numberBoxes = new TentacleNumberBox[numFields.Length];
                            for (int j = 0; j < numFields.Length; j++)
                            {
                                if (i == numFields[j])
                                {
                                    TentacleNumberBox numberBox = new TentacleNumberBox(i, subTable.panel);
                                    numberBoxes[j] = numberBox;
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
                    TentacleTextBox TextBox1 = new TentacleTextBox(groupBox);
                    TextBoxes[0] = TextBox1;
                    //AddTextBox();
                }
            }
            else if (isCollapsable == true)
            {
                cTable = table;
                ExpandButton1 = new TentacleButton(groupBox, "Expand", ColourManager.expandButtonColours);
                ExpandButton1.Click += new EventHandler(this.ToggleExpansion);
                isExpanded = false;
                cTable.panel.Visible = false;
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
            isExpanded = false;
            cTable.panel.Visible = false;

            //RemoveButton1.Click += new EventHandler(this.ToggleExpansion);
        }

        private void ToggleExpansion(Object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            groupBox.SuspendLayout();
            if (isExpanded == true)
            {
                isExpanded = false;
                cTable.panel.Visible = false;
                ExpandButton1.Text = "Expand";
            }
            else
            {
                isExpanded = true;
                cTable.panel.Visible = true;
                ExpandButton1.Text = "Collapse";
            }
            groupBox.ResumeLayout();
            Cursor.Current = Cursors.Default;
        }

        public override void SetChildControls(CollapsableTable cTable)
        {
            cTable.panel.Parent = groupBox;
            groupBox.Controls.Add(cTable.panel);
        }
    }

}
