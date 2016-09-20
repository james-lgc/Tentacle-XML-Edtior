using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
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
            fullAppPanel.BackColor = ColourManager.backGroundColour;
            form.Controls.Add(fullAppPanel);
            fullAppPanel.Dock = DockStyle.Fill;
            fullAppPanel.BringToFront();
            fullAppPanel.Show();

            Panel subPanel = new Panel();
            subPanel.BackColor = ColourManager.backGroundColour;
            subPanel.ForeColor = ColourManager.backGroundColour;
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
            loadingLabel.BackColor = ColourManager.backGroundColour;
            loadingLabel.ForeColor = ColourManager.textColour;
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
            progressBar.ForeColor = ColourManager.textColour;
            progressBar.BackColor = ColourManager.backGroundColour;

            //progressBar.Anchor = AnchorStyles.Bottom;
            Calculate(cList);
            progressBar.Maximum = totalCalculations;
        }

        public void IncreaseProgress()
        {
            currentProgress++;
            SetProgress();
        }

        private void SetProgress()
        {
            progressBar.Value = currentProgress;
        }

        private void Calculate(ConversationList cList)
        {
            totalCalculations = 0;
            for (int i = 0; i < cList.conversations.Length; i++)
            {
                Conversation conversation = cList.conversations[i];
                totalCalculations++;
                for (int j = 0; j < conversation.storyStages.Length; j++)
                {
                    StoryStage storyStage = conversation.storyStages[j];
                    totalCalculations++;
                    for (int k = 0; k <storyStage.conversationStages.Length; k++)
                    {
                        ConversationStage cStage = storyStage.conversationStages[k];
                        totalCalculations++;
                        for (int m = 0; m < cStage.lines.Length; m++)
                        {
                            Line line = cStage.lines[m];
                            totalCalculations++;
                            if (line.replies != null && line.replies.Length > 0)
                            {
                                for (int n = 0; n < line.replies.Length; n++)
                                {
                                    totalCalculations++;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
