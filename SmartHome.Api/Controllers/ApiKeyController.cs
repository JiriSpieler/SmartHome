using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Api.Attributes;

namespace SmartHome.Api.Controllers
{
    [ApiKey]
    public abstract class ApiKeyController : BaseController
    {
        protected ApiKeyController()
            : base()
        {
        }
    }
}
