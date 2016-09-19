﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class TableSizer
    {
        public static void AutoSize(TableLayoutPanel panel)
        {
            panel.AutoSize = true;
            panel.Dock = DockStyle.Fill;
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            panel.ColumnStyles.Clear();
            for (int i = 0; i < panel.ColumnCount; i++)
            {
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }
            panel.RowStyles.Clear();
            for (int i = 0; i < panel.RowCount; i++)
            {
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
        }

        public static void SetSize(TableLayoutPanel panel)
        {
            panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

        }
    }
}
