using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hayvanatbahcesi
{
    internal class Dog : Animal
    {
        public String Dogcolor { get; private set; }
        public Dog(string name, int age, int legs, String color) : base(name, age, legs)
        {
            Dogcolor = color;
        }
        public void dogshow()
        {
            Console.WriteLine("Dog Name: {0}, Age: {1}, Legs: {2}, Color: {3}", Name, Age, Legs, Dogcolor);
        }
        public static void dogspeak()
        {
            Console.WriteLine("Dogs says: woof");
        }
        public override bool run()
        {
            Console.WriteLine("Dogs can run");
            return true;
        }


    }
}
