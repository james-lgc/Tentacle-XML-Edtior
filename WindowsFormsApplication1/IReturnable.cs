using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public interface IReturnable
    {
        IReturnable[] Returnables { get; set; }

        IReturnable GetNewReturnable();


        //void Return();
    }
}
