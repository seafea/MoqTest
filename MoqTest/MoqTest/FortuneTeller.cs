using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqTest
{
    public class FortuneTeller
    {
        private IFortuneRepository _fortuneRepository;
        private IRandomNumberGenerator _randomNumberGenerator;

        public FortuneTeller(IFortuneRepository fortuneRepository, IRandomNumberGenerator randomNumberGenerator)
        {
            _fortuneRepository = fortuneRepository;
            _randomNumberGenerator = randomNumberGenerator;
        }

        public string GetFortune()

        {
            var fortunes = _fortuneRepository.GetFortunes("good");
            int randomNumber = _randomNumberGenerator.GetRandomNumber(0, fortunes.Length);
            return fortunes[randomNumber];
        }

        public string getRandomTypeFortune()
        {
            var fortuneTypes = _fortuneRepository.GetTypes();
            int randomNumberFortuneType = _randomNumberGenerator.GetRandomNumber(0, fortuneTypes.Length);
            var fortunes = _fortuneRepository.GetFortunes(fortuneTypes[randomNumberFortuneType]);
            int randomNumberFortune = _randomNumberGenerator.GetRandomNumber(0, fortunes.Length);
            return fortunes[randomNumberFortune];
        }
    }
}
