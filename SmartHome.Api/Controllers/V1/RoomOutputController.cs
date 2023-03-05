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
    public class RoomOutputController : ApiKeyController
    {
        private readonly Params _params;
        private readonly IUoW _uow;
        private readonly IMapper _mapper;
        public RoomOutputController(IOptions<Params> options, IUoW uow, IMapper mapper)
            : base()
        {
            _params = options.Value;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<RoomOutputModel>> Get(int id)
            => await Get(async () =>
            {
                return _mapper.Map<RoomOutput, RoomOutputModel>(await _uow.RoomOutputEx.GetRoomOutputAsync(id));
            });

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<RoomOutputModel>>> List()
            => await Get(async () =>
            {
                return _mapper.Map<List<RoomOutput>, List<RoomOutputModel>>(await _uow.RoomOutputEx.GetRoomOutputsAsync());
            });

        [HttpPost]
        [Route("post")]
        public async Task<ActionResult<bool>> Add(RoomOutputAddModel model)
            => await Get(async () =>
            {
                await _uow.RoomOutputEx.AddRoomOutputAsync(model);

                await _uow.CommitSMAsync();

                return true;
            });
    }
}
