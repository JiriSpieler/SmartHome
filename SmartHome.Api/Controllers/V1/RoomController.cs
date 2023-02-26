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
    }
}
