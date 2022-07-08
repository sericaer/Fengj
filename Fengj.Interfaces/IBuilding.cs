using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces
{
    public interface IBuliding
    {
        (int x, int y) pos { get; }

        Dictionary<Type, IOutput> outputDict { get; } 

        public interface IOutput
        {
            IBuliding from { get; }
            IGood good { get; }
        }
    }


}
