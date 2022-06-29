using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class NatureHeightMapBuilder : HeightMapBuilder
{
    public override Dictionary<(int x, int y), float> Build(int startIndex, int endIndex)
    {
        var positions = Enumerable.Range(startIndex, endIndex - startIndex)
            .SelectMany(x => Enumerable.Range(startIndex, endIndex - startIndex).Select(y => (x, y)))
            .ToArray();

        var mountCoreIndex = new HashSet<(int x, int y)>();
        while(mountCoreIndex.Count < System.Math.Max(positions.Length / 200, 3))
        {
            mountCoreIndex.Add(positions[Random.Range(0, positions.Length)]);
        }

        var rslt = new Dictionary<(int x, int y), int>();
        foreach (var index in mountCoreIndex)
        {
            rslt.Add(index, 100);
        }

        IEnumerable<(int x, int y)> curr = rslt.Keys;

        while (rslt.Count() < positions.Count())
        {
            var neighborGroups = curr.Select(x => (key: x, values: x.GetNeighbors().Where(x => positions.Contains(x)))).ToArray();
            foreach (var group in neighborGroups)
            {
                foreach (var neighbor in group.values)
                {
                    if (rslt.ContainsKey(neighbor))
                    {
                        continue;
                    }

                    rslt.Add(neighbor, System.Math.Max(rslt[group.key] - Random.Range(0, 10), -100));
                }
            }

            curr = neighborGroups.SelectMany(x => x.values).Distinct();
        }

        return rslt.ToDictionary(x=>x.Key, y=>(y.Value+100)/200f);
    }
}

static class Externtions
{
    public static IEnumerable<(int x, int y)> GetNeighbors(this (int x, int y) self)
    {
        return new (int x, int y)[]
        {
            (self.x+1, self.y),
            (self.x+1, self.y+1),
            (self.x+1, self.y-1),
            (self.x, self.y+1),
            (self.x, self.y-1),
            (self.x-1, self.y),
            (self.x-1, self.y+1),
            (self.x-1, self.y-1),
        };
    }
}