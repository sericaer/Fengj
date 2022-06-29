using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class HeightMapBuilder
{
    public static HeightMapBuilder Berlin = new BerlinHeightMapBuilder();
    public static HeightMapBuilder WhiteNose = new WhiteNoseHeightMapBuilder();
    public static HeightMapBuilder Nature = new NatureHeightMapBuilder();
    public abstract Dictionary<(int x, int y), float> Build(int startIndex, int endIndex);
}