using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise1
{
    static class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Animal>
            {
               new Cat("Tom", 23, "Female"),
               new Cat("Tom", 3, "Female"),
               new Dog("Milo", 10, "Male")
            };
            Console.WriteLine("Kind Animal {0} ", Animal.kindAnimal("Meo meo"));
            Console.WriteLine("Kind Animal {0} ", Animal.kindAnimal("Gau Gau"));
            var average = Animal.AverageAge(list);
            foreach(var kind in average)
            {
                Console.WriteLine("Age average of {0} is {1}", kind.Key, kind.Value);
            }
            Console.ReadKey();
        }
    }
}
