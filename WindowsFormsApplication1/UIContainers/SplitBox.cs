using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class SplitBox
    {
        public TableLayoutPanel panel;
        public Label label;
        public TextBox textBox;
        public NumericUpDown numUpDown;

        public SplitBox(Form1 form, TableLayoutPanel parentPanel, int rowNum, string labelText, string textBoxtext = null, int num =0)
        {
            panel = new TableLayoutPanel();
            parentPanel.Controls.Add(panel);
            panel.ColumnCount = 2;
            panel.RowCount = 1;
            panel.Dock = DockStyle.Fill;
            panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            label = new Label();
            form.Controls.Add(label);
            label.Parent = panel;
            label.Text = labelText;
            panel.SetColumn(label, 0);
            panel.Parent = parentPanel;
            parentPanel.SetRow(panel, rowNum);
            parentPanel.SetColumn(panel, 0);
            //panel.BackColor = System.Drawing.Color.Green;
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //panel.Size = new System.Drawing.Size(70, 20);
            panel.RowStyles.Clear();
            //panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.BringToFront();
            panel.Show();

            if (labelText != null)
            {
                textBox = new TextBox();
                form.Controls.Add(textBox);
                textBox.Parent = panel;
                panel.SetColumn(textBox, 1);
                panel.SetRow(textBox, 0);
            }
            else
            {
                numUpDown = new NumericUpDown();
                form.Controls.Add(numUpDown);
                numUpDown.Parent = panel;
                panel.SetColumn(numUpDown, 1);
            }
        }
    }
}
