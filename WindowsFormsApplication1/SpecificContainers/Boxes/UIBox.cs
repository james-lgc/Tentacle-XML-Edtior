using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public abstract class UIBox<X> : SpecificContainer
    {
        public X thisX { get; set; }

        protected void SetUp(X sentX)
        {
            thisX = sentX;
        }

        public void SaveContents()
        {

        }

        public virtual X ReturnX()
        {
            return thisX;
        }
        
    }
}
