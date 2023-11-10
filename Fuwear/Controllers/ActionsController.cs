using FuwearServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuwearAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionsController : ControllerBase
    {
        private readonly IActionsService iActionsService;

        public ActionsController(IActionsService iActionsService)
        {
            this.iActionsService = iActionsService ?? throw new ArgumentNullException(nameof(iActionsService));
        }

        [HttpGet()]
        [Route("/action")]
        public async Task<IActionResult> GetAction()
        {
            var actions = new[] { "AMZN", "CACC", "EQIX", "GOOG", "ORLY", "ULTA" };
            var prices = new[,]
            {
                { 12.81, 11.09, 12.11, 10.93, 9.83, 8.14 },
                { 10.34, 10.56, 10.14, 12.17, 13.1, 11.22 },
                { 11.53, 10.67, 10.42, 11.88, 11.77, 10.21 }
            };


            var actionWithHighestAvgPrice = await this.iActionsService.GetActionWithHighestAvgPrice(actions, prices);
            return Ok(actionWithHighestAvgPrice);
        }

    }
}
