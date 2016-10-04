using System;
using TentacleXMLEditor.UIElements;

namespace TentacleXMLEditor.Interfaces
{
    public interface IExpandable
    {
        bool isExpanded { get; set; }
        TentacleTable cTable { get; set; }

        void ToggleExpansion();
    }
}
