using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;
using SmartHome.Dao.Dao;
using SmartHome.Repository;

namespace SmartHome.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class InputController : ApiKeyController
    {
        private readonly Params _params;
        private readonly IUoW _uow;
        private readonly IMapper _mapper;
        public InputController(IOptions<Params> options, IUoW uow, IMapper mapper)
            : base()
        {
            _params = options.Value;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<InputModel>> Get(int id)
            => await Get(async () =>
            {
                return _mapper.Map<Input, InputModel>(await _uow.InputEx.GetInputAsync(id));
            });

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<InputModel>>> List()
            => await Get(async () =>
            {
                return _mapper.Map<List<Input>, List<InputModel>>(await _uow.InputEx.GetInputsAsync());
            });

        [HttpPost]
        [Route("post")]
        public async Task<ActionResult<bool>> Add(InputAddModel model)
            => await Get(async () =>
            {
                await _uow.InputEx.AddInputAsync(model);

                await _uow.CommitSMAsync();

                return true;
            });
    }
}
