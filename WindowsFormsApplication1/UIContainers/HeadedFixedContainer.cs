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
        Button button;
        public GroupBox groupBox;
        public TextBox[] textBoxes;
        public IExpandable expandable;
        private CollapsableTable cTable;
        private bool isExpanded;

        public HeadedFixedContainer(Form1 form, TableLayoutPanel parentPanel, int rowNum, string labelText)
        {
            groupBox = new GroupBox();
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

        public void AddHeading(Form1 form, CollapsableTable table, int fields, string[] labelTexts)
        {
            if (fields > 0)
            {
                CollapsableTable subTable = new CollapsableTable(form, this, fields, 3, 0);
                subTable.panel.Dock = DockStyle.Top;
                cTable = table;

                textBoxes = new TextBox[fields];
                for (int i = 0; i < fields; i++)
                {
                    Label label = new Label();
                    label.Parent = groupBox;
                    label.Text = labelTexts[i];
                    label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    label.Parent = subTable.panel;
                    subTable.panel.SetRow(label, i);
                    subTable.panel.SetColumn(label, 1);
                    subTable.panel.Controls.Add(label);

                    TextBox nameTextBox = new TextBox();
                    nameTextBox.Parent = groupBox;
                    nameTextBox.Parent = subTable.panel;
                    subTable.panel.SetRow(nameTextBox, i);
                    subTable.panel.SetColumn(nameTextBox, 2);
                    subTable.panel.Controls.Add(nameTextBox);
                    textBoxes[i] = nameTextBox;

                    if (i == fields - 1)
                    {
                        button = new Button();
                        button.Text = "Expand";
                        button.Parent = subTable.panel;
                        subTable.panel.SetRow(button, i);
                        subTable.panel.SetColumn(button, 0);
                        subTable.panel.Controls.Add(button);
                        button.Click += new EventHandler(this.ToggleExpansion);
                    }
                }
                isExpanded = false;
                cTable.panel.Visible = false;
            }
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
