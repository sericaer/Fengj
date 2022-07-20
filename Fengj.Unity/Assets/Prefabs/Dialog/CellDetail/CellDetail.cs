using Fengj.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CellDetail : MonoBehaviour
{
    public Text terrain;
    public Text building;

    public InteractionContainer interactionContainer;

    internal Vector3Int pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        terrain.text = Global.session.map.dictTerrain[(pos.x, pos.y)].ToString();

        var buildingObj = Global.session.pawns.bulidings.SingleOrDefault(x => x.pos.x == pos.x && x.pos.y == pos.y);
        if(buildingObj != null)
        {
            building.text = ((IPawn)buildingObj)?.name;

            interactionContainer.target = buildingObj;
        }
    }

    public void OnClose()
    {
        Destroy(this.gameObject);
    }
}
