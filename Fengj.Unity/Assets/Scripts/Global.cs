using Fengj.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class Global
{
    public static IInitData initData;
    public static ISession session;
    public static IModder modder;
}

class Context : IContext
{
    public ISession session { get; set; }

    public IInteractiveAble target { get; set; }

    public Context(IInteractiveAble target)
    {
        this.session = Global.session;
        this.target = target;
    }
}
