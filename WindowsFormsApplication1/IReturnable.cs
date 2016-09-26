using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public interface IReturnable
    {
        List<IReturnable> Returnables { get; set; }

        IReturnable GetNewReturnable();

        void ReplaceContents(List<IReturnable> newContents);
        //void Return();
    }
}
