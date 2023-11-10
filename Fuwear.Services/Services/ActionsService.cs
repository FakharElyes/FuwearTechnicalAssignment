using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuwearServices.Services
{
    public class ActionsService : IActionsService
    {
        public async Task<DTOs.Action> GetActionWithHighestAvgPrice(string[] actions, double[,] prices)
        {
            if (actions == null || prices == null || actions.Length == 0 || prices.Length == 0)
            {
                return null;
            }

            var avgPriceActionDictionary = new Dictionary<string, double>();

            double avgPrice = 0;
            var index = 0;
            
            while(index < prices.GetLength(1))
            {
                for (var i = 0; i < prices.GetLength(0); i++)
                {
                    avgPrice += prices[i, index];
                }
                avgPrice /= prices.GetLength(0);
                avgPriceActionDictionary.Add(actions[index], avgPrice);
                avgPrice = 0;
                index++;
            }

            var highestActionPrice = avgPriceActionDictionary.OrderByDescending(kv => kv.Value).FirstOrDefault();

            var action = new DTOs.Action()
            {
                Name = highestActionPrice.Key,
                AvgPrice = highestActionPrice.Value
            };

            return action;
        }
    }
}
