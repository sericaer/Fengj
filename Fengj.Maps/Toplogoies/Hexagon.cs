using Fengj.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fengj.Maps.Toplogoies
{
    class Hexagon : IMap.IToplogoy
    {

        const int def = 1; //ODD_Q -1, EVEN_Q 1

        public IEnumerable<(int x, int y)> GetNeighbors((int x, int y) pos)
        {
            var axial = ToAxial(pos);

            return new (int x, int y)[]
            {
                (axial.q+1, axial.r),
                (axial.q+1, axial.r-1),
                (axial.q, axial.r-1),
                (axial.q-1, axial.r),
                (axial.q-1, axial.r+1),
                (axial.q, axial.r+1),
            }.Select(x=> ToOffset(x));
        }

        internal  (int x, int y) ToOffset((int q, int r) axial)
        {
            int col = axial.q;
            int row = axial.r + (int)((axial.q + def * (axial.q & 1)) / 2);

            return (row*-1, col);
        }

        internal (int q, int r) ToAxial((int row, int col) offset)
        {
            offset = (offset.row * -1, offset.col);

            int q = offset.col;
            int r = offset.row - (int)((offset.col + def * (offset.col & 1)) / 2);

            return (q, r);
        }
    }
}
