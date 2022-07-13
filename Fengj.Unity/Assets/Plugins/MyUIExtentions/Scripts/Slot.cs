using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount != 0)
        {
            return;
        }

        if(DragAbleItem.draggingItem.transform != null)
        {
            DragAbleItem.draggingItem.transform.SetParent(this.transform, true);
        }
    }

    public void Update()
    {
        
    }
}
