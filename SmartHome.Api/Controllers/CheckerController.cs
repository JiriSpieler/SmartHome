using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartHome.Application;

namespace SmartHome.Api.Controllers
{
    [Route("api/[controller]")]
    public class CheckerController : BaseController
    {
        private readonly Params _params;

        public CheckerController(IOptions<Params> options)
            : base()
        {
            _params = options.Value;
        }

        [HttpGet]
        [Route("status")]
        public async Task<ActionResult<string>> Status()
            => await Get(async () =>
            {
                return await Task.FromResult($"{_params.Cfg.AppName} status: OK");
            });
    }
}
