using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hayvanatbahcesi
{
    internal abstract class Animal : IFly, IRun, IMove, IJump
    {
        public  string Name { get; private set; }
        public  int Age { get; set; }
        public  int Legs { get; private set; }
        protected Animal(string name, int age, int legs)
        {
            Name = name;
            Age = age;
            Legs = legs;
        }

        public virtual bool fly()
        {
            Console.WriteLine("this animal can't flying");
            return false;
        }

        public virtual bool jump()
        {
            Console.WriteLine("this animal can't jump");
            return false;
        }
        public virtual bool run()
        {
            Console.WriteLine("this animal can't run");
            return false;
        }
        public virtual bool move()
        {
            Console.WriteLine("this animal can move");
            return true;
        }

    }

    interface IFly
    {
        bool fly();
    }
    interface IJump
    {
        bool jump();
    }
    interface IRun
    {
        bool run();
    }
    interface IMove
    {
        bool move();
    }

}
