using Fengj.Interfaces.Mods;
using Fengj.Sessions.Goods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Sessions.Entities.Buildings
{
    public class Farm : Building
    {
        public Farm((int x, int y) pos, IFarmDef def) : base(pos, def)
        {
            name = "farm";
            AddOutput(new Food() { Value = 500});
        }
    }
}
