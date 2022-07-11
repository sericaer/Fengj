using Fengj.Sessions.Goods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Sessions.Entities.Buildings
{
    public class Farm : Building
    {
        public Farm((int x, int y) pos) : base(pos)
        {
            AddOutput(new Food() { Value = 500});
        }
    }
}
