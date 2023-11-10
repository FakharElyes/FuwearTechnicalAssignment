using FuwearServices.Services;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FuwearTest
{
    [TestFixture]
    public class ActionsServiceTests
    {
        private IActionsService actionsService;

        [SetUp]
        public void Setup()
        {
            this.actionsService = new ActionsService();
        }

        [Test]
        public async Task TestGetActionWithHighestAvgPrice_WhenActionsAndPricesAreEmpty_ShouldReturnNull()
        {
            string[] actions = new string[0];
            double[,] prices = new double[0, 0];

            var result = await this.actionsService.GetActionWithHighestAvgPrice(actions, prices);

            Assert.IsNull(result);
        }

        [Test]
        public async Task TestGetActionWithHighestAvgPrice_WhenActionsAndPricesAreValid_ShouldReturnCorrectAction()
        {
            string[] actions = { "AMZN", "CACC", "EQIX", "GOOG", "ORLY", "ULTA" };
            double[,] prices =
            {
                { 12.81, 11.09, 12.11, 10.93, 9.83, 8.14 },
                { 10.34, 10.56, 10.14, 12.17, 13.1, 11.22 },
                { 11.53, 10.67, 10.42, 11.88, 11.77, 10.21 }
            };

            var result = await this.actionsService.GetActionWithHighestAvgPrice(actions, prices);

            Assert.IsNotNull(result);
            Assert.AreEqual("GOOG", result.Name);
            Assert.AreEqual(11.660000000000002, result.AvgPrice, 0.0001);
        }
    }
}
