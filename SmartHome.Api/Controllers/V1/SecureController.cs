using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartHome.Api.Attributes;

namespace SmartHome.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class SecureController : ApiKeyController
    {
        private readonly Params _params;

        public SecureController(IOptions<Params> options)
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
