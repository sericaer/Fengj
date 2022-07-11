using Fengj.Interfaces;
using Fengj.Sessions.Entities.Buildings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Sessions.Entities
{
    partial class PawnManager
    {
        public static class Builder
        {
            public static IPawn.IManager Build()
            {
                var rslt = new PawnManager();

                rslt.AddPawn(new Clan("C1", (0, 0), 1000, 20000));
                rslt.AddPawn(new Clan("C2", (0, 1), 2000, 30000));

                rslt.AddPawn(new Farm((0, 0)));
                rslt.AddPawn(new Farm((0, 1)));

                return rslt;
            }
        }
    }
}
