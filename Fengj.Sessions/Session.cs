using Fengj.Interfaces;
using Fengj.Sessions.Entities;
using Fengj.Sessions.Entities.Buildings;
using Fengj.Sessions.Relations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fengj.Sessions
{
    public partial class Session : ISession, IDisposable
    {
        public IDate date { get; internal set; }

        public IMap map { get; internal set; }

        public IClan player { get; internal set; }

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

            Building.GetToLaborRelations = (building) =>
            {
                return relationMgr.labor2WorkAbleRelations.Where(x => x.workAble == building);
            };

            Clan.LaborManager.GetToWorkAbleRelation = (labor) =>
            {
                return relationMgr.labor2WorkAbleRelations.Where(x => x.labor == labor).SingleOrDefault();
            };

            Clan.LaborManager.OnRemoveLabor.AddListener((labor) =>
            {
                relationMgr.RemoveLabor2WorkAble(x => x.labor == labor);
            });

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

        public void Dispose()
        {
            Clan.LaborManager.OnRemoveLabor.Clear();
            Clan.LaborManager.GetToWorkAbleRelation = null;
            Building.GetToLaborRelations = null;
            Building.GetToClanRelations = null;
            Clan.GetToBuildingsRelations = null;
        }
    }
}
