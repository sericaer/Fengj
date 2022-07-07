using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/MyUIExtentions/DialogPanel")]
public class DialogPanel : MonoBehaviour
{
    internal static GameObject CreateGameObject(GameObject parent)
    {
        GameObject instance = (GameObject)Instantiate(Resources.Load("DialogPanel"), parent.transform);
        return instance;
    }

    public Button closeButton;


    [HideInInspector]
    public bool isMode 
    {   
        get
        {
            return _isMode;
        }
        set
        {
            _isMode = value;

            var image = GetComponent<Image>();
            image.enabled = isMode;
        }
    }

    [HideInInspector]
    [SerializeField]
    private bool _isMode;

    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(() =>
        {
            Destroy(this.gameObject);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}