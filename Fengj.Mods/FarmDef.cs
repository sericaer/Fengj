using Fengj.Interfaces;
using Fengj.Interfaces.Mods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fengj.Mods
{
    internal class FarmDef : IFarmDef
    {
        private IEnumerable<IInteractionDef> interactionDefs = new IInteractionDef[]
        {
            new InteractionDef()
            {
                name = "RELEASE LABOR",
                isValid = (context) =>
                {
                    var building = context.target as IBuilding;
                    if(building == null)
                    {
                        throw new Exception();
                    }

                    return building.toLaborRelations.Any();
                },
                Trigger = (context) =>
                {
                    var building = context.target as IBuilding;
                    if(building == null)
                    {
                        throw new Exception();
                    }

                    var relations = building.toLaborRelations.ToArray();
                    foreach(var relation in relations)
                    {    
                        context.session.relationMgr.RemoveRelation(relation);
                    }
                }
            },
             new InteractionDef()
            {
                name = "OCCUPY LABOR",
                isValid = (context) =>
                {
                    var building = context.target as IBuilding;
                    if(building == null)
                    {
                        throw new Exception();
                    }


                    return !building.toLaborRelations.Any();
                },
                Trigger = (context) =>
                {
                    var building = context.target as IBuilding;
                    if(building == null)
                    {
                        throw new Exception();
                    }

                    context.session.relationMgr.AddLabor2WorkAble(context.session.player.laborMgr.all.First(x=>!x.isWorking), building);
                }
            }
        };

        public IEnumerable<IInteractionDef> GetVailidInteractionDefs(IContext building)
        {
            return interactionDefs.Where(x => x.isValid(building));
        }
    }
}