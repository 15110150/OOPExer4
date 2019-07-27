using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Excercise1
{
    internal class Animal
    {
        public Animal(string name, int age, string sex)
        {
            Name = name;
            Age = age;
            Sex = sex;
        }

        protected string Name { get; }
        protected int Age { get; }
        protected string Sex { get; }

        public virtual string MakeSound()
        {
            return string.Empty;
        }

        public static string kindAnimal(string sound)
        {
            var listInstance = Assembly.GetAssembly(typeof(Animal)).GetTypes()
                .Where(_ => _.IsSubclassOf(typeof(Animal)));
            foreach (Type type in listInstance)
            {
                var fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Where(fi => fi.IsLiteral && fi.Name == "SOUND")
                    .Select(x => x.GetRawConstantValue()).ToList();
                if (fieldInfos.Count > 0)
                {
                    if (fieldInfos[0].ToString() == sound)
                    {
                        return type.Name;
                    }
                }
            }
            return string.Empty;
        }

        public static List<KeyValuePair<string, double>> AverageAge(List<Animal> listAnimal)
        {
            var listAverageAgeQuery = listAnimal.GroupBy(t => new { KindName = t.GetType().Name })
                           .Select(g => new { Name = g.Key.KindName, Average = g.Average(p => p.Age) });
            var listAverageAge = new List<KeyValuePair<string, double>>();

            foreach (var kindAnimal in listAverageAgeQuery)
            {
                listAverageAge.Add(new KeyValuePair<string, double>(kindAnimal.Name, kindAnimal.Average));
            }

            return listAverageAge;
        }

    }
}