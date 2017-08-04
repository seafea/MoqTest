using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var fortuneRepository = new FortuneRepository();
            var randomNumberGeneratorRepository = new RandomNumberGenerator();
            var fortuneTeller = new FortuneTeller(fortuneRepository, randomNumberGeneratorRepository);

            Console.WriteLine("Hello!  here is your good fortune:");

            Console.WriteLine(fortuneTeller.GetFortune());

            Console.WriteLine("Now here is a random fortune:");
            Console.WriteLine(fortuneTeller.getRandomTypeFortune());
            Console.ReadLine();
        }
    }
}
