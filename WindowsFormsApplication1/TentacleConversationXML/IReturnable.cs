using System;
using System.Collections.Generic;

namespace TentacleConversationXML
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
