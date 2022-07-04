using Fengj.Interfaces;
using UnityEngine;

public class MapLogic : MonoBehaviour
{
    public IMap mapData;

    public Camera mapCamera;

    public TerrainTilemap terrainMap;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var elem in mapData.dictTerrain)
        {
            terrainMap.SetTerrain(new Vector3Int(elem.Key.x, elem.Key.y), elem.Value);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //��������ת��,�Ŵ���С��ͼ
        var scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0)
        {
            mapCamera.orthographicSize -= scrollWheel;
        }
    }

    internal void UpdateTerrainMap(int heightPercent, int humidityPercent)
    {
        mapData.SetTerrainPercent(heightPercent, humidityPercent);

        foreach (var elem in mapData.dictTerrain)
        {
            terrainMap.UpdateTerrain(new Vector3Int(elem.Key.x, elem.Key.y), elem.Value);
        }
    }
}
