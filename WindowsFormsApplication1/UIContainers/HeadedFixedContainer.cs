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
            groupBox.Text = labelText;
            label = new Label();
            form.Controls.Add(label);
            label.Parent = groupBox;
            label.Text = labelText;
        }
    }

}
