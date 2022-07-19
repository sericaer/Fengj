using Fengj.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text label;

    [Serializable]
    public class RadioEvent : UnityEvent<IClan> { }
    public RadioEvent onShowClanDetail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        label.text = Global.session.player.name;
    }

    public void OnShowDetail()
    {
        onShowClanDetail?.Invoke(Global.session.player);
    }
}
