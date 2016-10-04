using System;
using TentacleXMLEditor.Colours;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentacleXMLEditor.Interfaces
{
    public interface IColourable
    {
        TwoToneColour TTColour { get; set; }

        void SetColours();
    }
}
