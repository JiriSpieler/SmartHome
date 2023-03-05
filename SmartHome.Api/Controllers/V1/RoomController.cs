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
    public class RoomController : ApiKeyController
    {
        private readonly Params _params;
        private readonly IUoW _uow;
        private readonly IMapper _mapper;
        public RoomController(IOptions<Params> options, IUoW uow, IMapper mapper)
            : base()
        {
            _params = options.Value;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<RoomModel>> Get(int id)
            => await Get(async () =>
            {  
                return _mapper.Map<Room, RoomModel>(await _uow.RoomEx.GetRoomAsync(id));
            });

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<RoomModel>>> List()
            => await Get(async () =>
            {
                return _mapper.Map<List<Room>, List<RoomModel>>(await _uow.RoomEx.GetRoomsAsync());
            });

        [HttpPost]
        [Route("post")]
        public async Task<ActionResult<bool>> Add(RoomAddModel model)
            => await Get(async () =>
            {
                await _uow.RoomEx.AddRoomAsync(model);

                await _uow.CommitSMAsync();

                return true;
            });
    }
}
