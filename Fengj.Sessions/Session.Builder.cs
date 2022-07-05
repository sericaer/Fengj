using Fengj.Interfaces;
using Fengj.Maps;
using Fengj.Sessions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Sessions
{
    public partial class Session
    {
        public class Builder
        {
            public static ISession Build(IInitData initData)
            {
                var session = new Session();

                session.map = Map.Builder.Build(initData.seed, initData.mapSize, MapType.Hexagon);
                session.map.SetTerrainPercent(initData.mapHeightPercent, initData.mapHumidityPercent);

                session.pawns = PawnManager.Builder.Build();

                return session;
            }
        }
    }
}
