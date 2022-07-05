using Fengj.Interfaces;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PawnItem : MonoBehaviour
{
    public Tilemap tileMap;

    public Text label;
    public Image image;

    public IPawn pawnObj;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        label.text = pawnObj.name;
        gameObject.transform.position = tileMap.CellToWorld(new Vector3Int(pawnObj.pos.x, pawnObj.pos.y));
        this.name = pawnObj.name;
    }
}