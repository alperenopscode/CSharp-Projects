using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Application
{
    internal abstract class Animal : ICanFly, ICanMove, ICanRun, ICanJump
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        protected Animal(string _name, int _age)
        {
            Name = _name;
            Age = _age;
        }
        //INTERFACES IN THE CLASS
        public virtual void CanFly()
        {
            Console.WriteLine("This animal can't fly");
        }
        public virtual void CanRun()
        {
            Console.WriteLine("This animal can't run");
        }
        public virtual void CanMove()
        {
            Console.WriteLine("This animal can move");
        }
        public virtual void CanJump()
        {
            Console.WriteLine("This animal can't jump");
        }
    }
    //INTERFACES
    interface ICanFly
    {
        void CanFly();
    }
    interface ICanJump
    {
        void CanJump();
    }
    interface ICanRun
    {
        void CanRun();
    }
    interface ICanMove
    {
        void CanMove();
    }
}