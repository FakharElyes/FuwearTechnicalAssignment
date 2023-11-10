using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuwearServices.Services
{
    public interface IActionsService
    {
        public Task<DTOs.Action> GetActionWithHighestAvgPrice(string[] actions, double[,] prices);
    }
}
