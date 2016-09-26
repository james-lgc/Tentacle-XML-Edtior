using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class BoxInformationContainer
    {
        private BoxInformation[] boxInfos;
        private DataBindingInfo[] info;
        public BoxInformation[] BoxInfos { get { return boxInfos; } }

        public BoxInformationContainer()
        {
            boxInfos = new BoxInformation[6];

            boxInfos[0] = new BoxInformation(boxLabel: "Conversations", isCollapsable: false, extraText: "Conversation");

            info = new DataBindingInfo[1];
            info[0] = new DataBindingInfo("name", true);
            boxInfos[1] = new BoxInformation(fields: 1, labelTexts: new string[] { "Name" }, extraText: "Name", bindingInfo: info);

            info = new DataBindingInfo[2];
            info[0] = new DataBindingInfo("storyThread", true);
            info[1] = new DataBindingInfo("stageNumber", false);
            boxInfos[2] = new BoxInformation(boxLabel: "StoryStages", fields: 2, numFields: new int[] { 1 }, labelTexts: new string[] { "StoryThread", "StageNumber" }, extraText: "StoryStage", bindingInfo: info);

            //info = new DataBindingInfo[1];
            //info[0] = new DataBindingInfo("", true);
            boxInfos[3] = new BoxInformation(boxLabel: "Dialogue", fields: 1, numFields: new int[] { 0 }, labelTexts:  new string[] { "Dialogue Id" }, extraText: "Dialogue");

            info = new DataBindingInfo[1];
            info[0] = new DataBindingInfo("lineText", true);
            boxInfos[4] = new BoxInformation(boxLabel: "Lines", fields: 1, labelTexts: new string[] { "Speech" }, isCollapsable: true, extraText: "Line", bindingInfo: info);

            info = new DataBindingInfo[1];
            info[0] = new DataBindingInfo("replyText", true);
            boxInfos[5] = new BoxInformation(boxLabel: null, fields: 1, labelTexts: new string[] { "Reply" }, isCollapsable: false, extraText: "Reply", bindingInfo: info);
        }
    }
}
