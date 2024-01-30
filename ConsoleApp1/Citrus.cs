using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Citrus : Fruit
    {
        public double VitaminC { get; set; }
        public Citrus(string name, string colour, double vitaminC) : base(name, colour)
        {
            VitaminC = vitaminC;
        }

        public Citrus()
        {

        }
        public override void Input()
        {
            Console.Write("Name:");
            Name = Console.ReadLine();
            Console.Write("Colour:");
            Colour = Console.ReadLine();
            Console.Write("Vitamin C(g):");
            VitaminC = double.Parse(Console.ReadLine());
        }
        public virtual void Input(string path)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(this.ToString());
            }
        }

        public override void Print()
        {
            Console.WriteLine(ToString());
        }
        public virtual void Print(string path)
        {
            using (StreamReader sw = new StreamReader(path, true))
            {
                Console.WriteLine(sw.ReadToEnd());
            }
        }
        public override string ToString()
        {
            return $"Name:{Name}, Colour:{Colour}, Vitamin C(g):{VitaminC}";
        }
    }
}
