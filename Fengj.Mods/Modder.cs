using Fengj.Interfaces;
using Fengj.Interfaces.Mods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fengj.Mods
{
    public class Modder : IModder
    {
        public string[] seeds => seedString.Split("\n").ToArray();

        public IEnumerable<IModDef> defs { get; } = new IModDef[]
        {
            new FarmDef(),
            new TerrainDef()
            {
                terrain = TerrainType.Hill,
                GetVailidInteractionDefs = (context) =>
                {
                    return Enumerable.Empty<IInteractionDef>();
                }
            },
            new TerrainDef()
            {
                terrain = TerrainType.Mount,
                GetVailidInteractionDefs = (context) =>
                {
                    return Enumerable.Empty<IInteractionDef>();
                }
            },
            new TerrainDef()
            {
                terrain = TerrainType.Plain,
                GetVailidInteractionDefs = (context) =>
                {
                    return Enumerable.Empty<IInteractionDef>();
                }
            },
            new TerrainDef()
            {
                terrain = TerrainType.Marsh,
                GetVailidInteractionDefs = (context) =>
                {
                    return Enumerable.Empty<IInteractionDef>();
                }
            },
            new TerrainDef()
            {
                terrain = TerrainType.Water,
                GetVailidInteractionDefs = (context) =>
                {
                    return Enumerable.Empty<IInteractionDef>();
                }
            }
        };





































        private string seedString = @"世世享德，万邦作式
率由典常，以蕃王室
不矜细行，终累大德
为山九仞，功亏一篑
受有亿兆夷人，离心离德
予有乱臣十人，同心同德
始于家邦，终于四海
民惟邦本，本固邦宁
箫韶九成，凤皇来仪
人心惟危，道心惟微
惟精惟一，允执厥中
克明俊德，以亲九族
九族既睦，平章百姓
百姓昭明，协和万邦
心之忧危，若蹈虎尾
任贤勿贰，去邪勿疑
任贤勿贰，去邪勿疑
惟天地万物父母
惟人万物之灵
允恭克让，光被四表
临下以简，御众以宽
罚弗及嗣，赏延于世
克宽克仁，彰信兆民
旧染污俗，咸与维新
野无遗贤，万邦咸宁
制治于未乱，保邦于未危
兄弟阋于墙，外御其务
我心匪石，不可转也
我心匪席，不可卷也
蒹葭苍苍，白露为霜
所谓伊人，在水一方
岂曰无衣?与子同袍
岂曰无衣?与子同泽
关关雎鸠，在河之洲
桃之夭夭，烁烁其华
之子与归，易其室家
昔我往矣，杨柳依依
巧笑倩兮，美目盼兮
今我来思，雨雪霏霏
呦呦鹿鸣，食野之苹
我有嘉宾，鼓瑟吹笙
南有乔木，不可休思
汉有游女，不可求思
天命玄鸟，降而生商
君子豹变，其文蔚也";

    }
}
