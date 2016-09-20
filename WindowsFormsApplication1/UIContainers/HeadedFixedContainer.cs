﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class HeadedFixedContainer : UIContainer
    {
        private ExpandButton ExpandButton1 { get; set; }
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
                        TentacleLabel tLabel = new TentacleLabel(labelTexts[i], i, subTable.panel);
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
                            ExpandButton1 = new ExpandButton(subTable, i);
                            ExpandButton1.Click += new EventHandler(this.ToggleExpansion);
                            isExpanded = false;
                            cTable.panel.Visible = false;
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
            
        }

        private void ToggleExpansion(Object sender, EventArgs e)
        {
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
        }

        public override void SetChildControls(CollapsableTable cTable)
        {
            cTable.panel.Parent = groupBox;
            groupBox.Controls.Add(cTable.panel);
        }
    }

}
