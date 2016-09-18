using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class HeadedFixedContainer : HeadedContainer
    {
        public Label label;

        public HeadedFixedContainer(Form1 form, TableLayoutPanel parentPanel, int rowNum, string labelText)
        {
            base.SetUp(form, parentPanel, rowNum);
            Label label = new Label();
            label.Text = labelText;
            label.Parent = panel;
            panel.SetRow(label, 0);
            panel.SetColumn(label, 0);
            panel.Controls.Add(label);
        }
    }

}
