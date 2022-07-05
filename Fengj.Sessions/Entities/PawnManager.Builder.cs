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
                    pos = (0, 0)
                });
                rslt.AddPawn(new Clan()
                {
                    name = "C2",
                    pos = (0, 1)
                });

                return rslt;
            }
        }
    }
}
