using Fengj.Interfaces;
using Fengj.Interfaces.Mods;
using Fengj.Maps;
using Fengj.Sessions.Cells;
using Fengj.Sessions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fengj.Sessions
{
    public partial class Session
    {
        public class Builder
        {
            public static ISession Build(IInitData initData, IEnumerable<IModDef> modDefs)
            {
                var session = new Session();

                session.map = Map.Builder.Build(initData.seed, initData.mapSize, MapType.Hexagon);
                session.map.SetTerrainPercent(initData.mapHeightPercent, initData.mapHumidityPercent);

                session.cells = CellManager.Builder.Build(session.map, modDefs);
                session.pawns = PawnManager.Builder.Build(modDefs);

                session.relationMgr.AddClan2Building(session.pawns.clans.ElementAt(0), session.pawns.bulidings.ElementAt(0));
                session.relationMgr.AddClan2Building(session.pawns.clans.ElementAt(1), session.pawns.bulidings.ElementAt(1));

                session.relationMgr.AddLabor2WorkAble(session.pawns.clans.ElementAt(0).laborMgr.all.ElementAt(0), session.pawns.bulidings.ElementAt(0));
                session.relationMgr.AddLabor2WorkAble(session.pawns.clans.ElementAt(1).laborMgr.all.ElementAt(0), session.pawns.bulidings.ElementAt(1));

                session.player = session.pawns.clans.ElementAt(0);
                return session;
            }
        }
    }
}
