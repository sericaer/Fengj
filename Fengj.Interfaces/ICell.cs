using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces
{
    public interface ICell : IInteractiveAble
    {
        (int x, int y) pos { get; }
        TerrainType terrain { get; }

        interface IManager
        {
            ICell this[(int x, int y) key] { get; }
        }
    }
}
