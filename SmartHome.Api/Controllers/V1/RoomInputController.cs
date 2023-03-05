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
    public class RoomInputController : ApiKeyController
    {
        private readonly Params _params;
        private readonly IUoW _uow;
        private readonly IMapper _mapper;
        public RoomInputController(IOptions<Params> options, IUoW uow, IMapper mapper)
            : base()
        {
            _params = options.Value;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<RoomInputModel>> Get(int id)
            => await Get(async () =>
            {
                return _mapper.Map<RoomInput, RoomInputModel>(await _uow.RoomInputEx.GetRoomInputAsync(id));
            });

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<RoomInputModel>>> List()
            => await Get(async () =>
            {
                return _mapper.Map<List<RoomInput>, List<RoomInputModel>>(await _uow.RoomInputEx.GetRoomInputsAsync());
            });

        [HttpPost]
        [Route("post")]
        public async Task<ActionResult<bool>> Add(RoomInputAddModel model)
            => await Get(async () =>
            {
                await _uow.RoomInputEx.AddRoomInputAsync(model);

                await _uow.CommitSMAsync();

                return true;
            });
    }
}
