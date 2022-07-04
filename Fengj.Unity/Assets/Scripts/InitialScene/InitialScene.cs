using Fengj.Interfaces;
using Fengj.Sessions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fengj.InitDatas;
using UnityEngine.UI;

public class InitialScene : MonoBehaviour
{
    public InputField seed;

    public Button confirm;

    // Start is called before the first frame update
    void Start()
    {
        seed.text = DateTime.Now.ToString();

        var initData = new InitData();

        initData.mapSize = 100;
        initData.mapHeightPercent = 80;
        initData.mapHumidityPercent = 20;

        confirm.onClick.AddListener(() =>
        {
            initData.seed = seed.text;

            var async = SceneManager.LoadSceneAsync(nameof(MainScene), LoadSceneMode.Single);
            async.completed += _ =>
            {
                Global.session = Session.Builder.Build(initData);
            };
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}