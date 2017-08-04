
using System;

namespace MoqTest
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int GetRandomNumber(int min, int max)
        {
            var random = new Random();

            return random.Next(min, max);
        }
    }
}