using ConsoleApp1;
using static ConsoleApp1.Fruit;

namespace TestProject1

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Fruit fr = new Fruit("Name", "Brown");

            var expected = "Name:Name, Colour:Brown";

            var actual = fr.ToString();

            Assert.AreEqual(expected, actual);

        }
    }
}