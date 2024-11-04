using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hayvanatbahcesi
{
    internal class Monkey : Animal
    {
        public int Taillength { get; private set; }
        public string Monkeycolor { get; set; }
        public Monkey(string name, int age, int legs, int taillegth, string monkeycolor) : base(name, age, legs)
        {
            Taillength = taillegth;
            Monkeycolor = monkeycolor;
        }
        public void Monkeyshow()
        {
            Console.WriteLine("Monkey Name: {0}, Age: {1}, Legs: {2}, Color: {3}, Taillegth: {4}", Name, Age, Legs, Monkeycolor, Taillength);
        }
        public override bool jump()
        {
            Console.WriteLine("Monkeys can jump");
            return true;
        }
        public override bool run()
        {
            Console.WriteLine("Monkeys can run");
            return true;
        }


    }
}

