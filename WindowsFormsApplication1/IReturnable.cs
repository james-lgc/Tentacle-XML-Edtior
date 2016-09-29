using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentacleXMLEditor
{
    public interface IReturnable
    {
        List<IReturnable> Returnables { get; set; }

        IReturnable GetNewReturnable();

        void ReplaceContents(List<IReturnable> newContents);
        void Build();
        void AddToList(IReturnable newReturnable);
        void RemoveAt(int index);
        void MoveAt(int change, int index);
    }
}
