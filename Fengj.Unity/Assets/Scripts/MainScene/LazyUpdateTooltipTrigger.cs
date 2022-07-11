using ModelShark;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TooltipTrigger))]
public class LazyUpdateTooltipTrigger : MonoBehaviour
{
    public Func<TipInfo> funcGetTipInfo;

    private TooltipTrigger tooltipTrigger;
    void Start()
    {
        tooltipTrigger = GetComponent<TooltipTrigger>();
        tooltipTrigger.actionBeforPopup = BeforPopup;
    }

    void BeforPopup()
    {
        if (funcGetTipInfo != null)
        {
            var tipInfo = funcGetTipInfo();

            tooltipTrigger.SetText("BodyText", tipInfo.bodyText);
        }
    }
}

public class TipInfo
{
    public string bodyText { get; set; }
}