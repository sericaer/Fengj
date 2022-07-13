using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAbleItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static DragAbleItem draggingItem;

    private Vector3 beginDragPosition;
    private Transform beginDragParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggingItem = this;
        beginDragPosition = this.transform.position;
        beginDragParent = this.transform.parent;

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggingItem = null;
        if(this.transform.parent == beginDragParent)
        {
            this.transform.position = beginDragPosition;
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;

        beginDragParent = null;
    }
}
