using Fengj.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    public MapLogic mapLogic;
    public PawnContainer pawnContainer;
    public TimeSpeedControl timeSpeedControl;
    public Canvas UICanvas;

    public Date date;

    public GameObject prefabPawnDetail;
    public GameObject prefabCellDetail;
    public GameObject prefabBuildingDetail;

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

    public void OnCellClick(Vector3Int pos)
    {
        var cellDetailDialog = UICanvas.GetComponentInChildren<CellDetail>();
        if(cellDetailDialog == null)
        {
            cellDetailDialog = Instantiate(prefabCellDetail, UICanvas.transform).GetComponent<CellDetail>();
        }

        cellDetailDialog.pos = pos;
    }

    public void OnShowClanDetail(IClan clan)
    {
        var pawnDetailDialog = Instantiate(prefabPawnDetail, UICanvas.transform).GetComponent<ClanDetails>();
        pawnDetailDialog.clan = clan;
    }

    public void OnShowPawnDetail(IPawn pawn)
    {
        switch(pawn)
        {
            case IClan clan:
                {
                    var pawnDetailDialog = Instantiate(prefabPawnDetail, UICanvas.transform).GetComponent<ClanDetails>();
                    pawnDetailDialog.clan = clan;
                }
                break;
            //case IBuliding building:
            //    {
            //        var buildingDetailDialog = Instantiate(prefabBuildingDetail, UICanvas.transform).GetComponent<BuildingDetails>();
            //        buildingDetailDialog.buildingObj = building;
            //    }
            //    break;
            default:
                throw new Exception();
        }
    }
}
