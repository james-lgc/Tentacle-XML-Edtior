using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class HeadedEditableContainer : HeadedContainer
    {

        public HeadedEditableContainer(Form1 form, TableLayoutPanel parentPanel, int rowNum, string labelText, string textBoxText, int upDownNum)
        {
            base.columnCount = 2;
            base.SetUp(form, parentPanel, rowNum);
            panel.ColumnCount = 2;
            TextBox textBox = new TextBox();
            textBox.Text = textBoxText;
            textBox.Parent = panel;
            panel.SetRow(textBox, 0);
            panel.SetColumn(textBox, 1);
            panel.Controls.Add(textBox);

            Label label = new Label();
            label.Text = labelText;
            label.Parent = panel;
            panel.SetRow(label, 0);
            panel.SetColumn(label, 0);
            panel.Controls.Add(label);

            TableSizer.AutoSize(panel);
            //splitBox = new SplitBox(form, groupBox, 0, labelText, textBoxText, upDownNum);
        }
    }
}
