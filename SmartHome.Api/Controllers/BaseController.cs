using Microsoft.AspNetCore.Mvc;

namespace SmartHome.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController : ControllerBase
    {
        public BaseController()
        {

        }
        protected async Task<T> GetData<T>(Func<Task<T>> get)
        {
            try
            {
                return await get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected async Task<ActionResult<T>> Get<T>(Func<Task<T>> get, Func<T, ActionResult<T>> @return = null)
        {
            try
            {
                var result = await GetData(get);
                return @return?.Invoke(result) ?? Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
