using Fengj.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Maps.Builders
{
    abstract partial class HeightMapBuilder
    {
        public static HeightMapBuilder Berlin = new BerlinBuilder();
        public static HeightMapBuilder WhiteNose = new WhiteNosieBuilder();
        public static HeightMapBuilder Nature = new NatureBuilder();
        public abstract Dictionary<(int x, int y), float> Build(int startIndex, int endIndex, IMap.IToplogoy toplogoy, Random random);
    }
}
