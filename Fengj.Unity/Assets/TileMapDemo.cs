using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapDemo : MonoBehaviour
{
    // Start is called before the first frame update

    public Tilemap map;

    void Start()
    {
        var tile = ScriptableObject.CreateInstance<Tile>();
        tile.sprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f), 1);


        var dictHeight = HeightMapBuilder.Nature.Build(0, 100);

        foreach (var elem in dictHeight)
        {
            var pos = new Vector3Int(elem.Key.x, elem.Key.y);

            map.SetTile(pos, tile);
            map.SetTileFlags(pos, TileFlags.None);

            map.SetColor(pos, new Color(elem.Value, elem.Value, elem.Value));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
