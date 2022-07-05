using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    public MapLogic mapLogic;
    public PawnContainer pawnContainer;

    // Start is called before the first frame update
    void Start()
    {
        mapLogic.mapData = Global.session.map;
        pawnContainer.pawns = Global.session.pawns;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
