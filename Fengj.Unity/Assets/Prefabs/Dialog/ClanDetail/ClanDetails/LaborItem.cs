using Fengj.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaborItem : MonoBehaviour
{
    public WorkInfo workInfo;

    public IClan.ILabor laborObj { get; set; }

    public void OnCancel()
    {
        Global.session.relationMgr.RemoveLabor2WorkAble(x => x.labor == laborObj);
    }

    // Start is called before the first frame update
    void Start()
    {
        workInfo.gameObject.SetActive(laborObj.isWorking);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        workInfo.gameObject.SetActive(laborObj.isWorking);
        if(workInfo.gameObject.activeSelf)
        {
            workInfo.label.text = laborObj.toWorkAbleRelation.workAble.name;
        }
    }
}
