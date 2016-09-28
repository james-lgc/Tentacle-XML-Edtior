using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentacleXMLEditor
{
    public class LoadingPanel
    {
        public Panel fullAppPanel;
        ProgressBar progressBar;
        Label mainLabel;
        Label loadingLabel;
        int totalCalculations;
        int currentProgress;

        public LoadingPanel(TentacleDoc form, ConversationList cList)
        {
            fullAppPanel = new Panel();
            fullAppPanel.Parent = form;
            //fullAppPanel.BackColor = ColourScheme.DarkBackGround.Colours[0];
            form.Controls.Add(fullAppPanel);
            fullAppPanel.Dock = DockStyle.Fill;
            fullAppPanel.BringToFront();
            fullAppPanel.Show();

            Panel subPanel = new Panel();
            //subPanel.BackColor = ColourScheme.DarkBackGround.Colours[0];
            //subPanel.ForeColor = ColourScheme.DarkBackGround.Colours[0];
            subPanel.BringToFront();
            subPanel.Show();
            subPanel.Parent = fullAppPanel;
            fullAppPanel.Controls.Add(subPanel);
            subPanel.AutoSize = true;
            //subPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            subPanel.Left = (fullAppPanel.ClientSize.Width - subPanel.Width)/2;
            subPanel.Top = (fullAppPanel.ClientSize.Height - subPanel.Height)/2;

            loadingLabel = new Label();
            loadingLabel.Parent = subPanel;
            loadingLabel.AutoSize = true;
            loadingLabel.Dock = DockStyle.Top;
            loadingLabel.Anchor = AnchorStyles.Top;
            subPanel.Controls.Add(loadingLabel);
            //loadingLabel.BackColor = ColourScheme.DarkBackGround.Colours[0];
            //loadingLabel.ForeColor = ColourScheme.DarkBackGround.Colours[1];
            loadingLabel.Text = "Loading...";

            progressBar = new ProgressBar();
            progressBar.Parent = subPanel;
            progressBar.Show();
            //progressBar.Dock = DockStyle.Fill;
            progressBar.Anchor = AnchorStyles.None;
            progressBar.BringToFront();
            subPanel.Controls.Add(progressBar);
            progressBar.Left = (subPanel.ClientSize.Width - progressBar.Width) / 2;
            progressBar.Top = (subPanel.ClientSize.Height - progressBar.Height) / 2;
            //progressBar.ForeColor = ColourScheme.DarkBackGround.Colours[0];
            //progressBar.BackColor = ColourScheme.DarkBackGround.Colours[0];

            //progressBar.Anchor = AnchorStyles.Bottom;
            Calculate(cList.Returnables);
            progressBar.Maximum = totalCalculations;
        }

        public void IncreaseProgress()
        {
            currentProgress++;
            SetProgress();
        }

        private void SetProgress()
        {
            if (currentProgress < progressBar.Maximum)
            {
                progressBar.Value = currentProgress;
            }
        }

        private void Calculate(List<IReturnable> returnables)
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
                }
            }
        }
    }
}
