using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;
using SmartHome.Application;
using SmartHome.Dao.Dao;
using SmartHome.Repository;

namespace SmartHome.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class OutputController : ApiKeyController
    {
        private readonly Params _params;
        private readonly IUoW _uow;
        private readonly IMapper _mapper;
        public OutputController(IOptions<Params> options, IUoW uow, IMapper mapper)
            : base()
        {
            _params = options.Value;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<OutputModel>> Get(int id)
            => await Get(async () =>
            {
                return _mapper.Map<Output, OutputModel>(await _uow.OutputEx.GetOutputAsync(id));
            });

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<OutputModel>>> List()
            => await Get(async () =>
            {
                return _mapper.Map<List<Output>, List<OutputModel>>(await _uow.OutputEx.GetOutputsAsync());
            });

        [HttpPost]
        [Route("post")]
        public async Task<ActionResult<bool>> Add(OutputAddModel model)
            => await Get(async () =>
            {
                await _uow.OutputEx.AddOutputAsync(model);

                await _uow.CommitSMAsync();

                return true;
            });
    }
}
