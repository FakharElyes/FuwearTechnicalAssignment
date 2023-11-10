using FuwearServices.Services;
using NUnit.Framework;
using System.Numerics;
using System.Threading.Tasks;

namespace FuwearTest
{
    [TestFixture]
    public class FibonacciServiceTests
    {
        private IFibonacciService fibonacciService;

        [SetUp]
        public void Setup()
        {
            this.fibonacciService = new FibonacciService();
        }

        [Test]
        public async Task TestCalculateFibonacciAsync_WhenIndiceIsZero_ShouldReturnZero()
        {
            int indice = 0;
            BigInteger expected = 0;

            BigInteger result = await this.fibonacciService.CalculateFibonacciAsync(indice);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public async Task TestCalculateFibonacciAsync_WhenIndiceIsOne_ShouldReturnOne()
        {
            int indice = 1;
            BigInteger expected = 1;

            BigInteger result = await this.fibonacciService.CalculateFibonacciAsync(indice);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public async Task TestCalculateFibonacciAsync_WhenIndiceIsGreaterThanOne_ShouldReturnCorrectValue()
        {
            int indice = 10;
            BigInteger expected = 55; 

            BigInteger result = await this.fibonacciService.CalculateFibonacciAsync(indice);

            Assert.AreEqual(expected, result);
        }
    }
}
