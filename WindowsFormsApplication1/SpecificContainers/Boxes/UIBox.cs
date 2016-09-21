using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public abstract class UIBox<X> : SpecificContainer
    {
        public X thisX { get; set; }
        public GroupBox GroupBox1 { get; set; }
        public UIBoxHeading<X> BoxHeading { get; set; }
        public CollapsableTable ChildCTable { get; set; }

        public UITable<X> ParentTable { get; set; }
        protected bool IsExpanded { get; set; }

        public int Fields { get; protected set; }
        public int ColumnCount { get; protected set; }
        public int[] NumFields { get; protected set; }
        public string[] LabelTexts { get; protected set; }
        public bool IsCollapsable { get; protected set; }


        protected void SetUp(X sentX, TentacleDoc form, UITable<X> parentTable, int rowNum, string labelText)
        {
            thisX = sentX;
            ParentTable = parentTable;

            GroupBox1 = new GroupBox();
            GroupBox1.BackColor = ColourManager.backGroundColour2;
            GroupBox1.ForeColor = ColourManager.textColour;
            GroupBox1.AutoSize = true;
            GroupBox1.Text = labelText;
            GroupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            GroupBox1.Dock = DockStyle.Fill;
            if (ParentTable.cTable.panel != null)
            {
                GroupBox1.Parent = ParentTable.cTable.panel;
                ParentTable.cTable.panel.SetCellPosition(GroupBox1, new TableLayoutPanelCellPosition(rowNum, ParentTable.cTable.panel.ColumnCount - 1));
                ParentTable.cTable.panel.Controls.Add(GroupBox1);
            }
            else
            {
                form.Controls.Add(GroupBox1);
            }
        }

        public void SaveContents()
        {

        }

        public virtual X ReturnX()
        {
            return thisX;
        }
    }
}
