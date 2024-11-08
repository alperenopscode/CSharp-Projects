using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Application
{
    internal class Monkey : Animal
    {
        public string Monkeycolor { get; private set; }
        public Monkey(string _name, int _age, string _monkeycolor) : base(_name,_age)
        {
            Monkeycolor = _monkeycolor;
        }
        internal static void MakeSound()
        {
            Console.WriteLine("\nMonkey says: uauaua");
        }

        //Interfaces
        public override void CanJump()
        {
            Console.WriteLine("Monkeys can jump");
        }
        public override void CanRun()
        {
            Console.WriteLine("Monkeys can run");
        }
    }
}
