using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Citrus), "Citrus")]
    public class Fruit : IComparable<Fruit>
    {
        public string Name { get; set; }
        public string Colour { get; set; }
        public Fruit(string name, string colour)
        {
            Name = name;
            Colour = colour;
        }

        public Fruit()
        {

        }

        public virtual void Input()
        {
            Console.Write("Name:");
            Name = Console.ReadLine();
            Console.Write("Colour:");
            Colour = Console.ReadLine();
        }

        public virtual void Input(string path)
        {
           
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(this.ToString());
            }

        }
        public virtual void Print()
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

            return $"Name:{Name}, Colour:{Colour}";
        }

        public static void Serialize(List<Fruit> fruits, string path)
        {
            string jsonString = JsonSerializer.Serialize(fruits, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(jsonString);
            }
        }

        public static List<Fruit> Deserialize(string path)
        {
            List<Fruit> deserializedObjects = JsonSerializer.Deserialize<List<Fruit>>(File.ReadAllText(path));
            return deserializedObjects;
        }





        public int CompareTo(Fruit? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }
}
