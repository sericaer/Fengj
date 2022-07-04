using Fengj.Interfaces;
using Fengj.Maps;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class HexTileMapDemo : MonoBehaviour
{
    public MapLogic mapLogic;

    public Slider heightSlider;
    public Slider waterSlider;


    void Awake()
    {
        var seed = "TEST";
        var mapData = Map.Builder.Build(seed, 100, MapType.Hexagon);

        mapLogic.mapData = mapData;
    }

    void Start()
    {
        heightSlider.onValueChanged.AddListener(_ => mapLogic.UpdateTerrainMap((int)heightSlider.value, (int)waterSlider.value));
        waterSlider.onValueChanged.AddListener(_ => mapLogic.UpdateTerrainMap((int)heightSlider.value, (int)waterSlider.value));
    }
}