using Fengj.Interfaces;
using Fengj.Interfaces.Mods;
using System;
using System.Collections.Generic;

namespace Fengj.Mods
{
    internal class TerrainDef : ITerrainDef
    {
        public TerrainType terrain { get; internal set; }

        public Func<IContext, IEnumerable<IInteractionDef>> GetVailidInteractionDefs { get; internal set; }
    }
}