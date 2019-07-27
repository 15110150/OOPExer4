using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise1
{
    class Cat : Animal
    {
        public const string SOUND = "Meo meo";
        public Cat(string name, int age, string sex) : base(name, age, sex)
        {
        }

        public override string MakeSound()
        {
            return SOUND;
        }
    }
}
