using Fengj.Interfaces;
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
                rslt.AddPawn(new Clan()
                {
                    name = "C1",
                    pos = (0, 0),
                    population = 1000,
                    supplies = 20000,
                });
                rslt.AddPawn(new Clan()
                {
                    name = "C2",
                    pos = (0, 1),
                    population = 2000,
                    supplies = 80000,
                });

                return rslt;
            }
        }
    }
}
