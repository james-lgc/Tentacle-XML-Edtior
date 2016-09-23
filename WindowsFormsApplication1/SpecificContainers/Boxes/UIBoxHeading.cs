﻿using System;
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
        private CollapsableTable HeadingTable { get; set; }
        public Control[] InputControls { get; set; }
        //public TentacleTextBox[] TextBoxes { get; set; }
        //public NumericUpDown[] NumberBoxes { get; set; }

        private TentacleButton ExpandButton1 { get; set; }
        private TentacleButton RemoveButton1 { get; set; }
        private TentaclePanel ButtonPanel { get; set; }

        public UIBoxHeading(UIBox sentBox)
        {
            ParentBox = sentBox;

            //string boxText = ParentBox.BoxInfo.BoxLabel;
            int fields = ParentBox.BoxInfo.Fields;
            string [] labelTexts = ParentBox.BoxInfo.LabelTexts;
            bool isCollapsable = ParentBox.BoxInfo.IsCollapsable;
            int[] numFields = ParentBox.BoxInfo.NumFields;
            int ColumnCount = ParentBox.BoxInfo.ColumnCount;

            //TextBoxes = new TentacleTextBox[Fields];
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
                    HeadingTable = new CollapsableTable(null, ParentBox.GroupBox1, rowCount: fields, columnCount: ColumnCount);
                    HeadingTable.panel.Dock = DockStyle.Top;
                    InputControls = new Control[fields];
                    for (int i = 0; i < fields; i++)
                    {
                        if (labelTexts != null)
                        {
                            TentacleLabel tLabel = new TentacleLabel(labelTexts[i], i, HeadingTable.panel);
                        }
                        if (numFields == null)
                        {
                            TentacleTextBox textBox = new TentacleTextBox(i, HeadingTable.panel);
                            InputControls[i] = textBox;
                        }
                        else
                        {
                            //NumberBoxes = new TentacleNumberBox[NumFields.Length];
                            for (int j = 0; j < numFields.Length; j++)
                            {
                                if (i == numFields[j])
                                {
                                    TentacleNumberBox numberBox = new TentacleNumberBox(i, HeadingTable.panel);
                                    InputControls[i] = numberBox;
                                    break;
                                }
                                else if (i == numFields.Length - 1)
                                {
                                    TentacleTextBox textBox = new TentacleTextBox(i, HeadingTable.panel);
                                    InputControls[i] = textBox;
                                    break;
                                }
                            }
                        }
                        if (i == fields - 1 && isCollapsable == true)
                        {
                            BuildButtons(HeadingTable, i);
                        }
                    }
                }
                else if (fields == 1)
                {
                    TentacleTextBox TextBox1 = new TentacleTextBox(ParentBox.GroupBox1);
                    InputControls[0] = TextBox1;
                    //AddTextBox();
                }
            }
            else if (isCollapsable == true)
            {
                //ParentTable = table;
                ExpandButton1 = new TentacleButton(ParentBox.GroupBox1, "Expand", ColourManager.expandButtonColours);
                ExpandButton1.Click += new EventHandler(this.ToggleExpansion);
                //ParentBox.ChildTable.cTable.IsExpanded = false;
                ParentBox.ChildTable.cTable.panel.Visible = false;
            }
            BindData(ParentBox.ThisX);
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
            //IsExpanded = false;
            ParentBox.ChildTable.cTable.panel.Visible = false;

            //RemoveButton1.Click += new EventHandler(this.ToggleExpansion);
        }

        public void BindData(IReturnable ThisX)
        {
            if (InputControls != null && InputControls.Length > 0 && ParentBox.BoxInfo.BindingInfo != null)
            {
                for (int i = 0; i < InputControls.Length; i++)
                {
                    if (ParentBox.BoxInfo.BindingInfo[i].IsText == true)
                    {
                        InputControls[i].DataBindings.Add("Text", ThisX, ParentBox.BoxInfo.BindingInfo[i].BindingProperty, false, DataSourceUpdateMode.OnPropertyChanged);
                    }
                    else
                    {
                        InputControls[i].DataBindings.Add("Value", ThisX, ParentBox.BoxInfo.BindingInfo[i].BindingProperty, false, DataSourceUpdateMode.OnPropertyChanged);
                    }
                }
            }
        }

        private void Remove()
        {

        }

        private void ToggleExpansion(Object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ParentBox.GroupBox1.SuspendLayout();
            if (ParentBox.ChildTable.cTable.panel.Visible == true)
            {
                //IsExpanded = false;
                ParentBox.ChildTable.cTable.panel.Visible = false;
                ExpandButton1.Text = "Expand";
            }
            else
            {
                //IsExpanded = true;
                ParentBox.ChildTable.cTable.panel.Visible = true;
                ExpandButton1.Text = "Collapse";
            }
            ParentBox.GroupBox1.ResumeLayout();
            Cursor.Current = Cursors.Default;
        }
    }
}
