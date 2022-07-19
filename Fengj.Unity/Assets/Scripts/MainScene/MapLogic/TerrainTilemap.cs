using Fengj.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainTilemap : MonoBehaviour
{
    public static Dictionary<TerrainType, Color> dictTerrainColor = new Dictionary<TerrainType, Color>()
    {
        { TerrainType.Plain, Color.green},
        { TerrainType.Hill, Color.yellow},
        { TerrainType.Mount, new Color(128 / 255f, 0, 128 / 255f)},
        { TerrainType.Marsh, new Color(95 / 255f, 158 / 255f, 160 / 255f)},
        { TerrainType.Water, Color.blue},
    };

    public Tilemap tilemap;

    public Sprite sprite;

    public Tile tile
    {
        get
        {
            if(_tile == null)
            {
                _tile = ScriptableObject.CreateInstance<Tile>();
                _tile.sprite = sprite;
            }

            return _tile;
        }
    }

    public GridLayout.CellLayout CellLayout => tilemap.cellLayout;

    private Tile _tile;

    internal void UpdateTerrain(Vector3Int pos, TerrainType value)
    {
        tilemap.SetColor(pos, dictTerrainColor[value]);
    }

    internal void SetTerrain(Vector3Int pos, TerrainType value)
    {
        tilemap.SetTile(pos, tile);

        tilemap.SetTileFlags(pos, TileFlags.None);

        tilemap.SetColor(pos, dictTerrainColor[value]);
    }

    internal Vector3Int WorldToCell(Vector2 mousePos)
    {
        return tilemap.WorldToCell(mousePos);
    }
}