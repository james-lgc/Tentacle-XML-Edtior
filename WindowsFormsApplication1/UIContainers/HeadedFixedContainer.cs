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
        Button button;
        private int columnCount;
        public GroupBox groupBox;
        public TextBox[] textBoxes;
        public IExpandable expandable;
        private CollapsableTable cTable;
        private bool isExpanded;

        public HeadedFixedContainer(Form1 form, TableLayoutPanel parentPanel, int rowNum, string labelText)
        {
            groupBox = new GroupBox();
            groupBox.BackColor = ColourManager.backGroundColour;
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

        public void AddHeading(Form1 form, CollapsableTable table, int fields, string[] labelTexts, bool isCollapsable)
        {
            textBoxes = new TextBox[fields];
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
                    CollapsableTable subTable = new CollapsableTable(form, this, rowCount: fields, columnCount: columnCount, rowNum: 0);
                    subTable.panel.Dock = DockStyle.Top;
                    cTable = table;
                    columnCount = 3;
                    for (int i = 0; i < fields; i++)
                    {
                        AddLabel(i, labelTexts[i], subTable);
                        AddTextBoxToTable(i, subTable);
                        if (i == fields - 1 && isCollapsable == true)
                        {
                            AddButton(subTable, i);
                            isExpanded = false;
                            cTable.panel.Visible = false;
                        }
                    }
                }
                else if (fields == 1)
                {
                    AddTextBox();
                }
            }
            
        }

        private void AddButton(CollapsableTable subTable, int i)
        {
            button = new Button();
            button.Text = "Expand";
            button.ForeColor = ColourManager.backGroundColour;
            button.BackColor = ColourManager.textColour;
            button.Parent = subTable.panel;
            subTable.panel.SetRow(button, i);
            subTable.panel.SetColumn(button, 0);
            subTable.panel.Controls.Add(button);
            button.Click += new EventHandler(this.ToggleExpansion);
        }

        private void AddLabel(int i, string labelText, CollapsableTable subTable)
        {
            Label label = new Label();
            label.Text = labelText;
            label.ForeColor = ColourManager.textColour;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label.Parent = subTable.panel;
            subTable.panel.SetRow(label, i);
            subTable.panel.SetColumn(label, columnCount -2);
            subTable.panel.Controls.Add(label);
        }

        private void AddTextBox()
        {
            TextBox nameTextBox = new TextBox();
            nameTextBox.Dock = DockStyle.Top;
            nameTextBox.ForeColor = ColourManager.backGroundColour;
            nameTextBox.BackColor = ColourManager.textColour;
            nameTextBox.Parent = groupBox;
            groupBox.Controls.Add(nameTextBox);
            textBoxes[0] = nameTextBox;
        }

        private void AddTextBoxToTable(int i, CollapsableTable subTable)
        {
            TextBox nameTextBox = new TextBox();
            nameTextBox.Parent = subTable.panel;
            nameTextBox.ForeColor = ColourManager.backGroundColour;
            nameTextBox.BackColor = ColourManager.textColour;
            subTable.panel.SetRow(nameTextBox, i);
            subTable.panel.SetColumn(nameTextBox, columnCount - 1);
            subTable.panel.Controls.Add(nameTextBox);
            nameTextBox.BringToFront();
            textBoxes[i] = nameTextBox;
        }

        private void ToggleExpansion(Object sender, EventArgs e)
        {
            if (isExpanded == true)
            {
                isExpanded = false;
                cTable.panel.Visible = false;
                button.Text = "Expand";
            }
            else
            {
                isExpanded = true;
                cTable.panel.Visible = true;
                button.Text = "Collapse";
            }
        }

        public override void SetChildControls(CollapsableTable cTable)
        {
            cTable.panel.Parent = groupBox;
            groupBox.Controls.Add(cTable.panel);
        }
    }

}
