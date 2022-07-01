using Fengj.Interfaces;
using Fengj.Maps.Builders;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class HexTileMapDemo : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite sprite;
    public Tilemap heightMap;
    public Tilemap terrainMap;
    public Toggle toggleHeightMap;
    public Toggle toggleColorMap;

    public Slider heightColorSlider;
    public Slider waterColorSlider;

    public Camera mapCamera;

    private Dictionary<(int x, int y), float> dictHeight;
    private IMap mapData;

    void Start()
    {
        mapCamera.orthographicSize = 50;

        var tile = ScriptableObject.CreateInstance<Tile>();
        tile.sprite = sprite;

        var seed = "TEST";
        mapData = MapBuilder.Build(seed, 100, MapType.Hexagon);

        foreach (var elem in mapData.dictHeight)
        {
            var pos = new Vector3Int(elem.Key.x, elem.Key.y);

            heightMap.SetTile(pos, tile);
            heightMap.SetTileFlags(pos, TileFlags.None);

            heightMap.SetColor(pos, new Color(elem.Value, elem.Value, elem.Value));
        }

        foreach(var elem in mapData.dictTerrain)
        {
            var pos = new Vector3Int(elem.Key.x, elem.Key.y);

            terrainMap.SetTile(pos, tile);

            terrainMap.SetTerrainColor(pos, elem.Value);
        }

        heightColorSlider.onValueChanged.AddListener(_ => UpdateTerrainMap());
        waterColorSlider.onValueChanged.AddListener(_ => UpdateTerrainMap());
    }


    private void UpdateTerrainMap()
    {
        mapData.SetTerrainPercent((int)heightColorSlider.value, (int)waterColorSlider.value);


        foreach (var elem in mapData.dictTerrain)
        {
            terrainMap.SetTerrainColor(new Vector3Int(elem.Key.x, elem.Key.y), elem.Value);
        }
    }

    // Update is called once per frame
    void Update()
    {
        heightMap.gameObject.SetActive(toggleHeightMap.isOn);
        terrainMap.gameObject.SetActive(toggleColorMap.isOn);

        //当鼠标滚轮转动,放大缩小地图
        var scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0)
        {
            mapCamera.orthographicSize -= scrollWheel;
        }
    }
}