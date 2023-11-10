using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FuwearServices.Services
{
    public interface IFibonacciService
    {
        public Task<BigInteger> CalculateFibonacciAsync(int indice);
    }
}
