using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentacleXMLEditor
{
    public interface IColourable
    {
        TwoToneColour TTColour { get; set; }

        void SetColours();
    }
}
