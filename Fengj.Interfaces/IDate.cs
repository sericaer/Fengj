using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Fengj.Interfaces
{
    public interface IDate
    {
        int year { get; set; }
        int month { get; set; }
        int day { get; set; }
    }
}
