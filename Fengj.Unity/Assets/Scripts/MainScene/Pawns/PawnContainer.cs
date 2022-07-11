using Fengj.Interfaces;
using System.Collections;
using UnityEngine;

public class PawnContainer : MonoBehaviour
{
    public PawnItem defaultPawn;

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

            _pawns = value;

            foreach(var elem in pawns.clans)
            {
                var newInst = Instantiate(defaultPawn.gameObject, this.transform);
                newInst.GetComponent<PawnItem>().pawnObj = elem;
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