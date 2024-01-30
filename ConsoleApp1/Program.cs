#define MANUAL
//#define CONSOLE
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                string pathToWriteTxt = Path.Combine(Directory.GetCurrentDirectory(), "Fruits.txt");
                string fullJsPath = Path.Combine(Directory.GetCurrentDirectory(), "FruitsJS.json");
                List<Fruit> fruits = new List<Fruit>();
#if MANUAL
                fruits.Add(new Citrus("Lemon", "Yellow", 31.2));
                fruits.Add(new Citrus("Orange", "Orange", 150));
                fruits.Add(new Fruit("Banana", "Yellow"));
                fruits.Add(new Fruit("Apple", "Red"));
                fruits.Add(new Fruit("Grape", "Violet"));
                fruits.Add(null);
#elif CONSOLE
                Fruit fr = new Fruit();
                Citrus ct = new Citrus();
                fr.Input();
                ct.Input();
                fruits.Add(fr);
                fruits.Add(ct);
#endif
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Yellow Fruits:");
                Console.ResetColor();
                foreach (var fruit in fruits)
                {
                    if (fruit != null && fruit.Colour == "Yellow" )
                    {
                        Console.WriteLine(fruit);
                    }
                }

                fruits = fruits.OrderBy(fruit => fruit).ToList();

                foreach (var fruit in fruits)
                {
                    if(fruit != null)
                    fruit.Input(pathToWriteTxt);
                }

                Fruit.Serialize(fruits, fullJsPath);

                var desFruits = Fruit.Deserialize(fullJsPath);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Deserialized Objects:");
                Console.ResetColor();
                foreach (var fruit in desFruits)
                {
                    if (fruit != null)
                        fruit.Print();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
