using Fengj.Interfaces;
using Fengj.Sessions.Entities.Buildings;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PawnContainer : MonoBehaviour
{
    public PawnItem defaultPawn;
    public PawnItem defaultFarmPawn;

    public  IEnumerable<PawnItem> items => defaultPawn.transform.parent.GetComponentsInChildren<PawnItem>();

    public IClan.IManager pawns
    {
        get
        {
            return _pawns;
        }
        set
        {
            if(_pawns != null)
            {
                throw new System.Exception();
            }

            defaultPawn.gameObject.SetActive(false);
            defaultFarmPawn.gameObject.SetActive(false);

            _pawns = value;

            //foreach(var elem in pawns.clans)
            //{
            //    var newInst = Instantiate(defaultPawn.gameObject, this.transform);
            //    newInst.GetComponent<PawnItem>().pawnObj = elem;
            //    newInst.gameObject.SetActive(true);
            //}

            foreach(var pawn in pawns.bulidings.OfType<Farm>())
            {
                var newInst = Instantiate(defaultFarmPawn.gameObject, this.transform);
                newInst.GetComponent<PawnItem>().pawnObj = pawn;
                newInst.gameObject.SetActive(true);
            }
        }
    }

    private IClan.IManager _pawns;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {

    }
}