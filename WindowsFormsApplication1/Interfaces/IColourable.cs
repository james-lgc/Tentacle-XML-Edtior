using System;
using TentacleXMLEditor.Colours;

namespace TentacleXMLEditor.Interfaces
{
    public interface IColourable
    {
        TwoToneColour TTColour { get; set; }

        void SetColours();
    }
}
