using Fengj.Interfaces;
using Fengj.Sessions.Entities;
using Fengj.Sessions.Goods;
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
        population.GetComponent<LazyUpdateTooltipTrigger>().funcGetTipInfo = () =>
        {
            return new TipInfo()
            {
                bodyText = string.Join("\n", clan.population.populationChangeds.Select(x => $"{x.percent: +0;-#}% {x.desc}"))
            };
        };

        supplies.GetComponent<LazyUpdateTooltipTrigger>().funcGetTipInfo = () =>
        {

            var foodMgr = clan.goodMgrs[typeof(Food)];

            return new TipInfo()
            {
                bodyText = string.Join("\n", foodMgr.income.Select(x => $"+{x.Value} {x.desc}")
                                                 .Concat(foodMgr.consume.Select(x => $"-{x.Value} {x.desc}")))
            };
        };
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        clanName.text = clan.name;
        population.text = $"{clan.population.total}({clan.population.populationChangeds.Sum(x=>x.percent) : +0;-#}%)";
        consumes.text = clan.consumers.OfType<LivingConsumer>().Single().average.ToString();

        var foodMgr = clan.goodMgrs[typeof(Food)];
        supplies.text = $"{foodMgr.good.Value}({foodMgr.income.Sum(x => x.Value) - foodMgr.consume.Sum(x => x.Value): +0;-#})";
    }
}
