using Fengj.Interfaces;
using Fengj.Interfaces.Mods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionItem : MonoBehaviour
{
    public Button button;
    public Text label;

    public IInteractionDef interactionObj;

    public IContext context;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(()=> interactionObj.Trigger(context));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        label.text = interactionObj.name;
    }
}
