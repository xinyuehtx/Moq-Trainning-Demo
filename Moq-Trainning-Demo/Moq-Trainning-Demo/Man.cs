using System;
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
        int GetAge();
        string SayHi(string friend);
        string DoSomething(string something);
        void Eat(int food);
    }
}
