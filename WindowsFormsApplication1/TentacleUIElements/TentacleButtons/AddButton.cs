using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class AddButton : TentacleButton
    {
        protected override void OnCreateControl()
        {
            baseColour = ColourManager.addButtonBaseColour;
            textColour = ColourManager.addButtonTextColour;
            base.OnCreateControl();
        }

        public AddButton(CollapsableTable cTable, string extraText)
        {
            Parent = cTable.panel;
            cTable.panel.SetRow(this, cTable.panel.RowCount -1);
            cTable.panel.SetColumn(this, 0);
            cTable.panel.Controls.Add(this);
            string addText = "Add ";
            string fullText = string.Concat(addText, extraText);
            Text = fullText;
            //Click += new EventHandler(cTable.AddRow());
        }
    }
}
