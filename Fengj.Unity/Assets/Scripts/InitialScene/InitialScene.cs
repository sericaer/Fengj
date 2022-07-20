using Fengj.Interfaces;
using Fengj.Sessions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fengj.InitDatas;
using UnityEngine.UI;
using System.Linq;
using Fengj.Mods;

public class InitialScene : MonoBehaviour
{
    public InputField seed;

    public Button confirm;
    public Button randomButton;

    // Start is called before the first frame update
    void Start()
    {

        Global.modder = new Modder();

        var initData = new InitData();

        initData.mapSize = 10;
        initData.mapHeightPercent = 80;
        initData.mapHumidityPercent = 20;

        confirm.onClick.AddListener(() =>
        {
            initData.seed = seed.text;

            var async = SceneManager.LoadSceneAsync(nameof(MainScene), LoadSceneMode.Single);
            async.completed += _ =>
            {
                Global.session = Session.Builder.Build(initData, Global.modder.defs);
            };
        });

        randomButton.onClick.AddListener(UpdateSeed);

        UpdateSeed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateSeed()
    {
        seed.text = Global.modder.seeds[UnityEngine.Random.Range(0, Global.modder.seeds.Length)];
    }
}