using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("UI/MyUIExtentions/DragDropContainer")]
public class DragDropContainer : MonoBehaviour
{
    public Slot slot;
    public DragAbleItem defaultItem;

    [HideInInspector]
    public bool isHaveItem
    {
        get
        {
            return _isHaveItem;
        }
        set
        {
            _isHaveItem = value;
            defaultItem.transform.SetParent(_isHaveItem ? slot.transform : null);
        }
    }

    [HideInInspector]
    [SerializeField]
    private bool _isHaveItem;

    internal static GameObject CreateGameObject(GameObject parent)
    {
        GameObject instance = (GameObject)Instantiate(Resources.Load("DragDropContainer"), parent.transform);
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!isHaveItem)
        {
            defaultItem.transform.SetParent(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
