using AutoMapper;
using Models;
using SmartHome.Dao.Dao;

namespace SmartHome.Api.Automapper
{
    public class RoomProfile : Profile
    {
        public RoomProfile() {
            CreateMap<Room, RoomModel>();
            CreateMap<RoomModel, Room>();
        }
    }
}
