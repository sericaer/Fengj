using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    public MapLogic mapLogic;
    public PawnContainer pawnContainer;
    public TimeSpeedControl timeSpeedControl;
    public Date date;

    // Start is called before the first frame update
    void Start()
    {
        mapLogic.mapData = Global.session.map;
        pawnContainer.pawns = Global.session.pawns;
        date.dateObj = Global.session.date;

        timeSpeedControl.timeIncEvent.AddListener(OnTimeInc);
    }

    void OnTimeInc()
    {
        Global.session.DaysInc();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
