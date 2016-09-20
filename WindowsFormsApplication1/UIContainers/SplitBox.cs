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

        public SplitBox(TentacleDoc form, TableLayoutPanel parentPanel, int rowNum, string labelText, string textBoxtext = null, int num =0)
        {
            panel = new TableLayoutPanel();
            parentPanel.Controls.Add(panel);
            panel.Parent = parentPanel;
            panel.ColumnCount = 2;
            panel.RowCount = 1;
            panel.Dock = DockStyle.Fill;
            panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            label = new Label();
            label.Parent = panel;
            panel.Controls.Add(label);
            label.Text = labelText;
            panel.SetColumn(label, 0);
            parentPanel.SetRow(panel, rowNum);
            parentPanel.SetColumn(panel, 0);
            //panel.BackColor = System.Drawing.Color.Green;
            //panel.Size = new System.Drawing.Size(70, 20);
            //panel.BringToFront();
            //panel.Show();
            if (labelText != null)
            {
                textBox = new TextBox();
                textBox.Parent = panel;
                panel.Controls.Add(textBox);
                panel.SetColumn(textBox, 1);
                panel.SetRow(textBox, 0);
            }
            else
            {
                numUpDown = new NumericUpDown();
                numUpDown.Parent = panel;
                panel.Controls.Add(numUpDown);
                panel.SetColumn(numUpDown, 1);
            }
            TableSizer.AutoSize(panel);
        }
    }
}
