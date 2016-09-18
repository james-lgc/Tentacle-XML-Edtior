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
        public SplitBox splitBox;

        public HeadedEditableContainer(Form1 form, TableLayoutPanel parentPanel, int rowNum, string labelText, string textBoxText, int upDownNum)
        {
            base.SetUp(form, parentPanel, rowNum);
            splitBox = new SplitBox(form, panel, 0, labelText, textBoxText, upDownNum);
        }
    }
}
