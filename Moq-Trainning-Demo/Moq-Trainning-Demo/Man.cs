﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moq_Trainning_Demo
{
    public interface IMan
    {
        string Name { get; set; }
        int Age { get; set; }
        int Weight { get; set; }
        string Occupation { get; set; }
        long Account { get; set; }
        IMan Child { get; set; }
        event EventHandler ImFull;
        string SayHi(string friend);
        string DoSomething<T>(string something, T arg);
        void Eat(int food);
    }
}
