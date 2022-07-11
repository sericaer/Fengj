using Fengj.Interfaces;
using Fengj.Sessions.Entities;
using Fengj.Sessions.Entities.Buildings;
using Fengj.Sessions.Relations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fengj.Sessions
{
    public partial class Session : ISession
    {
        public IDate date { get; internal set; }

        public IMap map { get; internal set; }

        public IPawn.IManager pawns { get; internal set; }

        public IRelationManager relationMgr { get; internal set; }

        public Session()
        {
            Clan.GetToBuildingsRelations = (clan) =>
            {
                return relationMgr.clan2BuidingRelations.Where(x => x.clan == clan);
            };

            Building.GetToClanRelations = (building) =>
            {
                return relationMgr.clan2BuidingRelations.Where(x => x.buliding == building);
            };

            date = new Date();
            relationMgr = new RelationManager();
        }

        public void DaysInc()
        {
            date.day++;

            foreach(var pawn in pawns.all)
            {
                pawn.OnDaysInc(date);
            }
        }
    }
}
