using Fengj.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LaborContainer : MonoBehaviour
{
    public LaborItem defaultItem;

    public IClan clan;

    public Transform container => defaultItem.transform.parent;

    // Start is called before the first frame update
    void Start()
    {
        defaultItem.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var showLabors = container.GetComponentsInChildren<LaborItem>();

        var needRemoveItems = showLabors.Where(x => clan.laborMgr.all.All(y => y != x.laborObj)).ToArray();
        var needAddObjects = clan.laborMgr.all.Except(showLabors.Select(x=>x.laborObj)).ToArray();

        foreach(var item in needRemoveItems)
        {
            Destroy(item.gameObject);
        }

        foreach(var obj in needAddObjects)
        {
            var newInst = Instantiate(defaultItem.gameObject, container);
            newInst.GetComponent<LaborItem>().laborObj = obj;
            newInst.gameObject.SetActive(true);
        }
    }
}
