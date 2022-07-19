using Fengj.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellDetail : MonoBehaviour
{
    public Text terrain;

    internal Vector3Int pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        terrain.text = Global.session.map.dictTerrain[(pos.x, pos.y)].ToString();
    }

    public void OnClose()
    {
        Destroy(this.gameObject);
    }
}
