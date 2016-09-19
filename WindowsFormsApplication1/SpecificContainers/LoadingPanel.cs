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
        Panel panel;
        ProgressBar progressBar;
        Label mainLabel;
        Label loadingLabel;
        int totalCalculations;
        int currentProgress;

        public void Initialize(ConversationList cList)
        {
            panel = new Panel();
            progressBar = new ProgressBar();
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
