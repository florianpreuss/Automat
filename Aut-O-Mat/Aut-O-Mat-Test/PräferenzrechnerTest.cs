using Aut_O_Mat_Lib.Database;
using Aut_O_Mat_Lib.Präferenzrechner;

namespace Aut_O_Mat_Test;

public class PräferenzrechnerTest
{
    public class DatabaseTest
    {
        private PräferenzrechnerFactory DatabaseFactory;
        private string RechnerName = ".\\testRechner1";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(RechnerName))
            {
                File.Delete(RechnerName);
            }

            Console.Write("Database Factory created!");
        }

        [Test]
        public void CreateFactoryTest()
        {
            DatabaseFactory = new PräferenzrechnerFactory();
            Console.Write("Database Factory created!");
            Assert.Pass();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}