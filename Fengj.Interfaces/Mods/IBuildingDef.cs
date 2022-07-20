using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces.Mods
{
    public interface IBuildingDef : IModDef
    {
        IEnumerable<IInteractionDef> GetVailidInteractionDefs(IContext context);
    }

    public interface IFarmDef : IBuildingDef
    {

    }
}
