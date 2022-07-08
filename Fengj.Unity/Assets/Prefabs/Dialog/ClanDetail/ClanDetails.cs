using Fengj.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ClanDetails : MonoBehaviour
{
    public Text clanName;
    public Text supplies;
    public Text population;
    public Text consumes;

    public IClan clan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        clanName.text = clan.name;
        population.text = $"{clan.population.total}({clan.population.populationChangeds.Sum(x=>x.percent) : +0;-#}%)";
        supplies.text = $"{clan.supplies}(-{clan.consume.total})";
        consumes.text = clan.consume.average.ToString();
    }
}
