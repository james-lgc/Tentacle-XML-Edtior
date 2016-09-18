using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public abstract class UITable<X>
    {
        public CollapsableTable cTable;
        public X[] xArray;
        protected List<UIBox<X>> boxes;

        protected void SetUp(Form1 form, HeadedContainer parent, int rowCount, int rowNum, X[] newX)
        { 
            cTable = new CollapsableTable(form, parent, rowCount, rowNum);
            xArray = newX;
            TableSizer.AutoSize(cTable.panel);
        }

        public void Expand()
        {
            TableSizer.AutoSize(cTable.panel);
        }
    }
}
