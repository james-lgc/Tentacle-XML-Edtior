using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentacleXMLEditor
{
    public interface IExpandable
    {
        bool isExpanded { get; set; }
        TentacleTable cTable { get; set; }

        void ToggleExpansion();
    }
}
