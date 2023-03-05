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
    public class ThermoRuleController : ApiKeyController
    {
        private readonly Params _params;
        private readonly IUoW _uow;
        private readonly IMapper _mapper;
        public ThermoRuleController(IOptions<Params> options, IUoW uow, IMapper mapper)
            : base()
        {
            _params = options.Value;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<ThermoRuleModel>> Get(int id)
            => await Get(async () =>
            {
                return _mapper.Map<ThermoRule, ThermoRuleModel>(await _uow.ThermoRuleEx.GetThermoRuleAsync(id));
            });

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<ThermoRuleModel>>> List()
            => await Get(async () =>
            {
                return _mapper.Map<List<ThermoRule>, List<ThermoRuleModel>>(await _uow.ThermoRuleEx.GetThermoRulesAsync());
            });

        [HttpPost]
        [Route("post")]
        public async Task<ActionResult<bool>> Add(ThermoRuleAddModel model)
            => await Get(async () =>
            {
                await _uow.ThermoRuleEx.AddThermoRuleAsync(model);

                await _uow.CommitSMAsync();

                return true;
            });
    }
}
