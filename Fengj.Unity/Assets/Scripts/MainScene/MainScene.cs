using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    public MapLogic mapLogic;

    // Start is called before the first frame update
    void Start()
    {
        mapLogic.mapData = Global.session.map;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
