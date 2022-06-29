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
        while (mountCoreIndex.Count < System.Math.Max(positions.Length / 200, 3))
        {
            mountCoreIndex.Add(positions[Random.Range(0, positions.Length)]);
        }

        var temp = new Dictionary<(int x, int y), int>();
        foreach (var index in mountCoreIndex)
        {
            temp.Add(index, 100);
        }

        IEnumerable<(int x, int y)> curr = temp.Keys;

        while (temp.Count() < 10000)
        {
            var needIndexs = curr.SelectMany(x => x.GetNeighbors()).Distinct().Where(x => positions.Contains(x) && !temp.ContainsKey(x)).ToArray();
            foreach(var need in needIndexs)
            {
                int average = (int)need.GetNeighbors().Where(x => temp.ContainsKey(x)).Average(x => temp[x]);
                temp.Add(need, System.Math.Max(average - Random.Range(-50, 100), -100));
            }

            curr = needIndexs;
        }


        return temp.ToDictionary(x=>x.Key, y=>(y.Value+100)/200f);
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
        }.OrderBy(_=>Random.Range(0, 100));
    }
}