using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FuwearServices.Services
{
    public class FibonacciService : IFibonacciService
    {
        public async Task<BigInteger> CalculateFibonacciAsync(int indice)
        {
            if (indice == 0)
            {
                return 0;
            }
            else if (indice == 1)
            {
                return 1;
            }

            BigInteger a = 0;
            BigInteger b = 1;
            BigInteger result = 0;

            for (var i = 2; i <= indice; i++)
            {
                result = a + b;
                a = b;
                b = result;
            }

            return result;
        }
    }
}
