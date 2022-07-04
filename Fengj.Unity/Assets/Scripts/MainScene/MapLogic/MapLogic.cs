using Fengj.Interfaces;
using Fengj.Maps;
using UnityEngine;

public class MapLogic : MonoBehaviour
{
    public Camera mapCamera;

    public TerrainTilemap terrainMap;

    public IMap mapData
    {
        get
        {
            return _mapData; // == null ? _defaultMapData : _mapData;
        }
        set
        {
            _mapData = value;

            foreach (var elem in mapData.dictTerrain)
            {
                terrainMap.SetTerrain(new Vector3Int(elem.Key.x, elem.Key.y), elem.Value);
            }
        }
    }

    private IMap _mapData;
    //private IMap _defaultMapData
    //{
    //    get
    //    {
    //        switch(terrainMap.CellLayout)
    //        {
    //            case GridLayout.CellLayout.Hexagon:
    //                return Map.defaultHexMap;
    //            case GridLayout.CellLayout.Rectangle:
    //                return Map.defaultRectMap;
    //            default:
    //                throw new System.Exception();
    //        }
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        //���������Ļ�߽磬�ƶ���ͼ
        var offsetPos = mapCamera.ScreenToViewportPoint(Input.mousePosition);
        if (offsetPos.x < 0.01 || offsetPos.y < 0.01 || offsetPos.x >= 0.99f || offsetPos.y >= 0.99f)
        {
            if (offsetPos.x < 0 || offsetPos.y < 0)
            {
                return;
            }

            Vector3 move = (offsetPos - new Vector3(0.5f, 0.5f)) * 0.1f;

            mapCamera.transform.position += move;

        }

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