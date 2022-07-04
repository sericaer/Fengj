using Fengj.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fengj.Maps.HeightMapBuilders
{
    class WhiteNosieBuilder : HeightMapBuilder
    {
        public override Dictionary<(int x, int y), float> Build(int startIndex, int endIndex, IMap.IToplogoy toplogoy, Random random)
        {
            var positions = Enumerable.Range(startIndex, endIndex - startIndex).SelectMany(x => Enumerable.Range(startIndex, endIndex - startIndex).Select(y => (x, y)));
            return positions.ToDictionary(key => key, value => (float)random.NextDouble());
        }
    }
}
