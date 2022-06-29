
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class BerlinHeightMapBuilder : HeightMapBuilder
{
    private Dictionary<(int x, int y), float> grandDict;

    public override Dictionary<(int x, int y), float> Build(int startIndex, int endIndex)
    {
        var positions = Enumerable.Range(startIndex, endIndex - startIndex).SelectMany(x => Enumerable.Range(startIndex, endIndex - startIndex).Select(y => (x, y)));

        grandDict = new Dictionary<(int x, int y), float>();
        for(int x=startIndex-10; x< endIndex+10; x+=10)
        {
            for(int y=startIndex-10; y<endIndex+10; y+=10)
            {
                grandDict.Add((x, y), Random.Range(0f, 1f));
            }
        }

        var rslt = new Dictionary<(int x, int y), float>();
        foreach (var pos in positions)
        {
            //if (grandDict.ContainsKey(pos))
            //{
            //    rslt.Add(pos, grandDict[pos]);
            //    continue;
            //}

            var p0 = (x: pos.x / 10 * 10, y: pos.y / 10 * 10);
            var p1 = (x: p0.x, y: p0.y + 10);
            var p2 = (x: p0.x + 10, y: p0.y + 10);
            var p3 = (x: p0.x + 10, y: p0.y);

            var step0 = GetStep2(p0);
            var step1 = GetStep2(p1);
            var step2 = GetStep2(p2);
            var step3 = GetStep2(p3);

            var vPostoP0 = (x: (pos.x - p0.x)/10f, y: (pos.y - p0.y)/10f);
            var vPostoP1 = (x: (pos.x - p1.x) / 10f, y: (pos.y - p1.y)/ 10f);
            var vPostoP2 = (x: (pos.x - p2.x) / 10f, y: (pos.y - p2.y)/ 10f);
            var vPostoP3 = (x: (pos.x - p3.x) / 10f, y: (pos.y - p3.y)/ 10f);

            float product0 = step0.x * vPostoP0.x + step0.y * vPostoP0.y;
            float product1 = step1.x * vPostoP1.x + step1.y * vPostoP1.y;
            float product2 = step2.x * vPostoP2.x + step2.y * vPostoP2.y;
            float product3 = step3.x * vPostoP3.x + step3.y * vPostoP3.y;

            // P1和P2的插值
            float d0 = vPostoP0.x;
            float t0 = (float)(6.0 * System.Math.Pow(d0, 5) - 15.0 * System.Math.Pow(d0, 4) + 10.0 * System.Math.Pow(d0, 3));
            float n0 = product1 * (1f - t0) + product2 * t0;

            // P0和P3的插值
            float n1 = product0 * (1f - t0) + product3 * t0;

            // P点的插值
            float d1 = vPostoP0.y;
            float t1 = (float)(6.0 * System.Math.Pow(d1, 5.0) - 15.0 * System.Math.Pow(d1, 4.0) + 10.0 * System.Math.Pow(d1, 3.0));

            float Value = n1 * (1 - t1) + n0 * t1;

            rslt.Add(pos, Value);
        }

        return rslt;
    }

    private (float x, float y) GetStep((int x, int y) pos)
    {
        var p0 = (x: pos.x-10, y: pos.y);
        var p1 = (x: pos.x, y: pos.y - 10);

        return (grandDict[pos] - grandDict[p0], grandDict[pos] - grandDict[p1]);
    }

    private (float x, float y) GetStep2((int x, int y) pos)
    {
        float[] vec = new float[2];
        vec[0] = pos.x * 127.1f + pos.y * 311.7f;
        vec[1] = pos.x * 269.5f + pos.y * 183.3f;

        float sin0 = (float)(System.Math.Sin(vec[0]) * 43758.5453123);
        float sin1 = (float)(System.Math.Sin(vec[1]) * 43758.5453123);
        vec[0] = (float)(sin0 - System.Math.Floor(sin0)) * 2.0f - 1.0f;
        vec[1] = (float)(sin1 - System.Math.Floor(sin1)) * 2.0f - 1.0f;

        // 归一化，尽量消除正方形的方向性偏差
        float len = (float)System.Math.Sqrt(vec[0] * vec[0] + vec[1] * vec[1]);
        vec[0] /= len;
        vec[1] /= len;

        return (vec[0], vec[1]);
    }
}