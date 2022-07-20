using Fengj.Interfaces;
using Fengj.Interfaces.Mods;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractionContainer : MonoBehaviour
{
    public InteractionItem defaultItem;
    public IInteractiveAble target
    {
        get
        {
            return context?.target;
        }
        set
        {
            context = new Context(value);
        }
    }

    private Transform container => defaultItem.transform.parent;
    private IContext context;

    private List<IContext> contexts = new List<IContext>();

    void Start()
    {
        defaultItem.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var showInteractions = container.GetComponentsInChildren<InteractionItem>();

        var needRemoveItems = showInteractions.Where(x => target.GetVaildInteractionDefs(context).All(y => y != x.interactionObj)).ToArray();
        var needAddObjects = target.GetVaildInteractionDefs(context).Except(showInteractions.Select(x => x.interactionObj)).ToArray();

        foreach (var item in needRemoveItems)
        {
            Destroy(item.gameObject);
        }

        foreach (var obj in needAddObjects)
        {
            var newInst = Instantiate(defaultItem.gameObject, container);
            newInst.GetComponent<InteractionItem>().interactionObj = obj;
            newInst.GetComponent<InteractionItem>().context = context;
            newInst.gameObject.SetActive(true);
        }
    }
}
