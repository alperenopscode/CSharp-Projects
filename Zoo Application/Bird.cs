using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Application
{
    internal class Bird : Animal
    {
        public string Birdcolor { get; private set; }
        public Bird(string _name, int _age, string _birdcolor) : base(_name, _age)
        {
            Birdcolor = _birdcolor;
        }
        internal static void MakeSound()
        {
            Console.WriteLine("\nBird says: Cik Cik");
        }

        //Interfaces
        public override void CanFly()
        {
            Console.WriteLine("Bird's can fly");
        }
    }
}
