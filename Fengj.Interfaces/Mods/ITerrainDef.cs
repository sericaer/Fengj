using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces.Mods
{
    public interface ITerrainDef : IModDef
    {
        TerrainType terrain { get; }

        Func<IContext, IEnumerable<IInteractionDef>> GetVailidInteractionDefs { get; }
    }
}
