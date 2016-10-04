using System;
using TentacleXMLEditor.ConversationSystem;
using TentacleXMLEditor.Colours;
using TentacleXMLEditor.Interfaces;
using TentacleXMLEditor.Processors;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentacleXMLEditor.UIElements
{
    public class TentacleLoadingPanel : Panel, IColourable
    {
        private Panel SubPanel { get; set; }

        public TwoToneColour TTColour { get; set; }

        private ProgressBar ProgressBar1 { get; set; }
        private TentacleLabel LoadingLabel { get; set; }
        int totalCalculations;
        int currentProgress;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Dock = DockStyle.Fill;
            BringToFront();
            Hide();
        }

        public TentacleLoadingPanel(TentacleDoc form, ConversationList cList)
        {
            Parenter.Parent(this, form);
            form.BeginLoading += ToggleVisible;
            form.EndLoading += ToggleVisible;
            BuildSubPanel();
            SetColours();
            BuildLabel();
            BuildProgressBar();
            Calculate(cList.Returnables);
            ProgressBar1.Maximum = totalCalculations;
        }

        private void BuildSubPanel()
        {
            SubPanel = new Panel();
            Parenter.Parent(SubPanel, this);
            SubPanel.Anchor = AnchorStyles.None;
            SubPanel.AutoSize = true;
            SubPanel.Left = (this.ClientSize.Width - SubPanel.Width) / 2;
            SubPanel.Top = (this.ClientSize.Height - SubPanel.Height) / 2;
        }

        private void BuildLabel()
        {
            LoadingLabel = new TentacleLabel("Loading", SubPanel);
            LoadingLabel.AutoSize = true;
            LoadingLabel.Dock = DockStyle.Top;
            LoadingLabel.Anchor = AnchorStyles.Top;
        }

        private void BuildProgressBar()
        {
            ProgressBar1 = new ProgressBar();
            Parenter.Parent(ProgressBar1, SubPanel);
            ProgressBar1.Show();
            ProgressBar1.Anchor = AnchorStyles.None;
            ProgressBar1.BringToFront();
            ProgressBar1.Left = (SubPanel.ClientSize.Width - ProgressBar1.Width) / 2;
            ProgressBar1.Top = (SubPanel.ClientSize.Height - ProgressBar1.Height) / 2;
        }

        public void IncreaseProgress()
        {
            currentProgress++;
            SetProgress();
        }

        private void SetProgress()
        {
            if (currentProgress < ProgressBar1.Maximum)
            {
                ProgressBar1.Value = currentProgress;
            }
        }

        private void Calculate(List<IReturnable> returnables)
        {
            if (returnables != null)
            {
                for (int i = 0; i < returnables.Count; i++)
                {
                    if (returnables.Count == 0 || returnables[i] == null)
                    {
                        break;
                    }
                    if (returnables[i] != null)
                    {
                        Calculate(returnables[i].Returnables);
                        totalCalculations++;
                    }
                }
            }
        }

        private void ToggleVisible(object sender, EventArgs e)
        {
            switch (Visible)
            {
                case true:
                    Visible = false;
                    SubPanel.BringToFront();
                    ProgressBar1.BringToFront();
                    break;
                case false:
                    Visible = true;
                    break;
            }
        }

        public void SetColours()
        {
            TTColour = ColourManager.CurrentTheme.DarkBackGround;
            Colourizer.Colourize(this, TTColour);
            Colourizer.Colourize(SubPanel, TTColour);
        }
    }
}
