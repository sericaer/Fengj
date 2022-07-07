using Fengj.Interfaces;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PawnItem : MonoBehaviour
{
    public Tilemap tileMap;

    public Text label;
    public Image image;
    public Button button;

    public IPawn pawnObj;

    [Serializable]
    public class RadioEvent : UnityEvent<PawnItem> { }
    public RadioEvent onShowPawnDetails;

    // Use this for initialization
    void Start()
    {
        button.onClick.AddListener(() =>
        {
            onShowPawnDetails?.Invoke(this);
        });
    }

    void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        label.text = pawnObj.name;
        gameObject.transform.position = tileMap.CellToWorld(new Vector3Int(pawnObj.pos.x, pawnObj.pos.y));
        this.name = pawnObj.name;
    }


}

