using Fengj.Interfaces;
using Fengj.Maps;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MapLogic : MonoBehaviour
{

    public Camera mapCamera;

    public TerrainTilemap terrainMap;
    public PawnContainer pawnContainer;

    [Serializable]
    public class RadioEvent : UnityEvent<Vector3Int> { }
    public RadioEvent onShowCellDetails;

    public IMap mapData
    {
        get
        {
            return _mapData; // == null ? _defaultMapData : _mapData;
        }
        set
        {
            _mapData = value;

            //foreach (var elem in mapData.dictTerrain)
            //{
            //    terrainMap.SetTerrain(new Vector3Int(elem.Key.x, elem.Key.y), elem.Value);
            //}
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
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = terrainMap.WorldToCell(mousePos);


            //if (tilemap.HasTile(gridPos))
            Debug.Log($"Hello World from {gridPos} {mapData.dictTerrain[(gridPos.x, gridPos.y)]}");

            onShowCellDetails?.Invoke(gridPos);
        }

        ////当鼠标在屏幕边界，移动地图
        //var offsetPos = mapCamera.ScreenToViewportPoint(Input.mousePosition);
        //if (offsetPos.x < 0.01 || offsetPos.y < 0.01 || offsetPos.x >= 0.99f || offsetPos.y >= 0.99f)
        //{
        //    if (offsetPos.x < 0 || offsetPos.y < 0)
        //    {
        //        return;
        //    }

        //    Vector3 move = (offsetPos - new Vector3(0.5f, 0.5f)) * 0.1f;

        //    mapCamera.transform.position += move;

        //}

        //当鼠标滚轮转动,放大缩小地图
        var scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0)
        {
            mapCamera.orthographicSize -= scrollWheel;

            //foreach(var pawn in pawnContainer.items)
            //{
            //    pawn.transform.localScale = mapCamera.orthographicSize
            //}
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
