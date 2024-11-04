using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hayvanatbahcesi
{
    internal class Bird : Animal
    {
        public string Birdcolor { get; set; }
        public Bird(string name, int age, int legs, string birdcolor) : base(name, age, legs)
        {
            Birdcolor = birdcolor;
        }

        public void Birdshow()
        {
            Console.WriteLine("Bird Name: {0}, Age: {1}, Legs: {2}, Color: {3}", Name, Age, Legs, Birdcolor);
        }
        public override bool fly()
        {
            Console.WriteLine("Birds can fly");
            return true;
        }
    }
}
