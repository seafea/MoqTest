using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using NUnit.Framework;
using Moq;

namespace MoqTest.Test
{
    [TestFixture]
    public class FortuneTellerTests
    {
        [Test]
        public void ReturnRandomGoodFortune()

        {
            Mock<IFortuneRepository> testFortuneRepository = new Mock<IFortuneRepository>();
            Mock<IRandomNumberGenerator> testRandomNumberGenerator = new Mock<IRandomNumberGenerator>();

            testFortuneRepository
                .Setup(x => x.GetFortunes("good"))
                .Returns(new[]
                {
                    "something good",
                    "something pretty good",
                    "something great",
                    "something silly",
                    "something that doesn't make sense"
                });

            testRandomNumberGenerator
                .Setup(x => x.GetRandomNumber(0, 5))
                .Returns(3);

            FortuneTeller testTeller = new FortuneTeller(testFortuneRepository.Object, testRandomNumberGenerator.Object);

            var results = testTeller.GetFortune();
            Assert.AreEqual("something silly", results);
        }
        // TODO write Unit test that gets a fortune of a random type.
        [Test]
        public void ReturnRandomTypeFortune()
        {
            Mock<IFortuneRepository> testFortuneRepository = new Mock<IFortuneRepository>();
            Mock<IRandomNumberGenerator> testRandomNumberGeneratorFortune = new Mock<IRandomNumberGenerator>();
            RandomNumberGenerator testRandomNumberGeneratorFortuneType = new RandomNumberGenerator();
            Dictionary<string, string[]> testFortunesByType;

            string[] fortuneTypes =
            {
                "good",
                "neutral",
                "bad"
            };
            testFortunesByType = new Dictionary<string, string[]>
            {
                {
                    "good",
                    new string[]
                    {
                        "something good",
                        "something pretty good",
                        "something great",
                        "something silly",
                        "something that doesn't make sense"
                    }
                },
                {
                    "neutral",
                    new string[]
                    {
                        "something neutral",
                        "something okay i guess",
                        "meh",
                        "whatever",
                        "idk lol"
                    }
                },
                {
                    "bad",
                    new string[]
                    {
                        "something bad",
                        "something awful",
                        "something silly but still kinda bad",
                        "something terrible",
                        "something that doesn't make any sense"
                    }
                },
            };

            string fortuneType = fortuneTypes[testRandomNumberGeneratorFortuneType.GetRandomNumber(0, fortuneTypes.Length)];

            testFortuneRepository.Setup(
                x => x.GetFortunes(fortuneTypes[0])).Returns(
                testFortunesByType[fortuneType]);

            testRandomNumberGeneratorFortune
                .Setup(x => x.GetRandomNumber(0, 4))
                .Returns(0);

            FortuneTeller testTeller = new FortuneTeller(testFortuneRepository.Object, testRandomNumberGeneratorFortune.Object);
            var result = testTeller.GetFortune();
            Assert.Contains(result, new string[]
            {
                "something good",
                "something neutral",
                "something bad"
            });
        }
    }
}
