using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Application
{
    internal class Dog : Animal
    {
        public string Dogcolor { get; private set; }
        public Dog(string _name, int _age, string _dogcolor) : base(_name, _age)
        {
            Dogcolor = _dogcolor;
        }
        internal static void MakeSound()
        {
            Console.WriteLine("\nDog says: hav hav");
        }

        //Interfaces
        public override void CanRun()
        {
            Console.WriteLine("Dogs can run");
        }


    }
}
