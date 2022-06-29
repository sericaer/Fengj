using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class WhiteNoseHeightMapBuilder : HeightMapBuilder
{
    public override Dictionary<(int x, int y), float> Build(int startIndex, int endIndex)
    {
        var positions = Enumerable.Range(startIndex, endIndex - startIndex).SelectMany(x => Enumerable.Range(startIndex, endIndex - startIndex).Select(y => (x, y)));
        return positions.ToDictionary(key => key, value => Random.Range(0f, 1f));
    }
}