using Fengj.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fengj.Maps.Toplogoies
{
    class RectangleTopology : IMap.IToplogoy
    {
        public IEnumerable<(int x, int y)> GetNeighbors((int x, int y) pos)
        {
            return new (int x, int y)[]
            {
                (pos.x+1, pos.y),
                (pos.x+1, pos.y+1),
                (pos.x+1, pos.y-1),
                (pos.x, pos.y+1),
                (pos.x, pos.y-1),
                (pos.x-1, pos.y),
                (pos.x-1, pos.y+1),
                (pos.x-1, pos.y-1),
            };
        }
    }
}
