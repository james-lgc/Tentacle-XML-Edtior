﻿using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class TentaclePanel : FlowLayoutPanel, IColourable
    {
        public TwoToneColour TTColour { get; set; }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Margin = Padding.Empty;
            Dock = DockStyle.Left;
        }

        public TentaclePanel(CollapsableTable cTable, int i) : base()
        {
            SetColours();
            FlowDirection = FlowDirection.LeftToRight;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Parenter.Parent(this, cTable.panel, i, 0);
        }

        public TentaclePanel(Control control)
        {
            SetColours();
            Parenter.Parent(this, control);
        }

        public void SetColours()
        {
            TTColour = ColourManager.CurrentTheme.DarkBackGround;
            Colourizer.Colourize(this, TTColour);
        }
    }
}
