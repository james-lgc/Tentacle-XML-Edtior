﻿using System;
using System.Windows.Forms;
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

        protected void SetUp(Form1 form, UIContainer parent, int rowCount, int columnCount, int rowNum, X[] newX, string[] labelTexts)
        { 
            cTable = new CollapsableTable(form, parent, rowCount, columnCount, rowNum);
            xArray = newX;
            if (labelTexts != null)
            {
                for (int i = 0; i < newX.Length; i++)
                {
                    Label label = new Label();
                    if (labelTexts.Length > 1)
                    {
                        label.Text = labelTexts[i];
                    }
                    else
                    {
                        label.Text = labelTexts[0];
                    }
                    label.Parent = cTable.panel;
                    cTable.panel.SetRow(label, i);
                    cTable.panel.SetColumn(label, 0);
                    cTable.panel.Controls.Add(label);
                }
            }

            TableSizer.AutoSize(cTable.panel);
        }

        public void Expand()
        {
            TableSizer.AutoSize(cTable.panel);
        }
    }
}
