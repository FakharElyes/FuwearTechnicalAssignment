using FuwearServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Fuwear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        private readonly IFibonacciService fibonacciService;
        public FibonacciController(IFibonacciService fibonacciService)
        {
            this.fibonacciService = fibonacciService ?? throw new ArgumentNullException(nameof(fibonacciService));
        }

        [HttpGet()]
        [Route("/fibonacci/{n}")]
        public async Task<IActionResult> GetFibonacci(int n)
        {
            if (n < 1 || n > 100)
            {
                return Ok(-1);
            }

            BigInteger result = await this.fibonacciService.CalculateFibonacciAsync(n);
            return Ok(result.ToString());
        }
    }
}
