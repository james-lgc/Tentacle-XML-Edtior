using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class SpecificContainer<X>
    {
        private X thisX;

        public virtual X ReturnX()
        {
            return thisX;
        }
    }
}
