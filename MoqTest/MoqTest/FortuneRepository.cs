using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqTest
{
    public class FortuneRepository : IFortuneRepository
    {
        private Dictionary<string, List<string>> _fortunesByType;

        public FortuneRepository()
        {
            _fortunesByType = new Dictionary<string, List<string>>
            {
                {
                    "good",
                    new List<string>
                    {
                        "everything will be okay!",
                        "you're a swell person!",
                        "no existential dread for you!",
                    }
                },
                {
                    "bad",
                    new List<string>
                    {
                        "you better watch out!",
                        "tomorrow you're gonna smell real bad!",
                        "you will win a free ticket to the emoji movie",
                    }
                },
                {
                    "neutral",
                    new List<string>
                    {
                        "tomorrow is definitely going to happen",
                        "you will get news very soon",
                        "you will have an okay day tomomrrow",
                    }
                },
            };
        }

        public string[] GetFortunes(string type)
        {
            return _fortunesByType[type].ToArray();
        }

        public string[] GetTypes()
        {
            return _fortunesByType.Keys.ToArray();
        }
    }
}
