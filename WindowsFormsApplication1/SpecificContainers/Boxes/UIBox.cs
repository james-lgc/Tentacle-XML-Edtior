using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class UIBox<X, Y> : SpecificContainer<X> where X : IReturnable<Y> where Y : X
    {
        //public CollapsableTable ChildTable {get; protected set; }
        public X ThisX { get; set; }
        public GroupBox GroupBox1 { get; set; }
        public UIBoxHeading<X, Y> BoxHeading { get; set; }
        public CollapsableTable ChildCTable { get; set; }

        public UITable<X> ParentTable { get; set; }
        protected bool IsExpanded { get; set; }

        public virtual string BoxLabel { get; }
        public virtual int Fields { get; }
        public virtual int ColumnCount { get; set; }
        public virtual int[] NumFields { get; }
        public virtual string[] LabelTexts { get; }
        public virtual bool IsCollapsable { get; }
        public virtual string ExtraText { get; }
        

        protected UITable<Y> ChildTable { get; set; }


        public void SetUp<Z>(X sentX, UITable<X> parentTable, int rowNum) where Z : UITable<Y>
        {
            ThisX = sentX;
            ParentTable = parentTable;

            GroupBox1 = new GroupBox();
            GroupBox1.BackColor = ColourManager.backGroundColour2;
            GroupBox1.ForeColor = ColourManager.textColour;
            GroupBox1.AutoSize = true;
            GroupBox1.Text = BoxLabel;
            GroupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            GroupBox1.Dock = DockStyle.Fill;
            if (ParentTable != null)
            {
                GroupBox1.Parent = ParentTable.cTable.panel;
                ParentTable.cTable.panel.SetCellPosition(GroupBox1, new TableLayoutPanelCellPosition(rowNum, ParentTable.cTable.panel.ColumnCount - 1));
                ParentTable.cTable.panel.Controls.Add(GroupBox1);
            }
            IReturnable<Y>[] yArray = ThisX.Returnables as IReturnable<Y>[];
            ChildTable = (Z)Activator.CreateInstance(typeof(Z), GroupBox1, yArray.Length, ColumnCount, yArray as Y[], ExtraText);
            //(GroupBox1, yArray.Length, columnCount, yArray as Y[], extraText);
        }
        /*protected void AssignTable(UITable<Y, Z> table)
        {
            if (table != null)
            {
                ChildTable = table;
                ChildCTable = table.cTable;
            }
            BoxHeading = new UIBoxHeading<X, Y>(this);
        }*/

        public void SaveContents()
        {

        }

        public virtual X ReturnX()
        {
            return ThisX;
        }
    }
}
