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
    public class RoomThermoRuleController : ApiKeyController
    {
        private readonly Params _params;
        private readonly IUoW _uow;
        private readonly IMapper _mapper;
        public RoomThermoRuleController(IOptions<Params> options, IUoW uow, IMapper mapper)
            : base()
        {
            _params = options.Value;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<RoomThermoRuleModel>> Get(int id)
            => await Get(async () =>
            {
                return _mapper.Map<RoomThermoRule, RoomThermoRuleModel>(await _uow.RoomThermoRuleEx.GetRoomThermoRuleAsync(id));
            });

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<RoomThermoRuleModel>>> List()
            => await Get(async () =>
            {
                return _mapper.Map<List<RoomThermoRule>, List<RoomThermoRuleModel>>(await _uow.RoomThermoRuleEx.GetRoomThermoRulesAsync());
            });

        [HttpPost]
        [Route("post")]
        public async Task<ActionResult<bool>> Add(RoomThermoRuleAddModel model)
            => await Get(async () =>
            {
                await _uow.RoomThermoRuleEx.AddRoomThermoRuleAsync(model);

                await _uow.CommitSMAsync();

                return true;
            });
    }
}
