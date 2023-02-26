using AutoMapper;
using Models;
using SmartHome.Dao.Dao;
using System.Collections.Generic;

namespace SmartHome.Api.Automapper
{
    public class RoomProfile : Profile
    {
        public RoomProfile() {
            CreateMap<Room, RoomModel>();
            CreateMap<RoomModel, Room>();

            CreateMap<Input, InputModel>();
            CreateMap<InputModel, Input>();

            CreateMap<Output, OutputModel>();
            CreateMap<OutputModel, Output>();
        }
    }
}
