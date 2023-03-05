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

            CreateMap<Input, InputModel>();
            CreateMap<InputModel, Input>();

            CreateMap<Output, OutputModel>();
            CreateMap<OutputModel, Output>();

            CreateMap<ThermoRule, ThermoRuleModel>();
            CreateMap<ThermoRuleModel, ThermoRule>();

            CreateMap<RoomThermoRule, RoomThermoRuleModel>();
            CreateMap<RoomThermoRuleModel, RoomThermoRule>();

            CreateMap<RoomInput, RoomInputModel>();
            CreateMap<RoomInputModel, RoomInput>();

            CreateMap<RoomOutput, RoomOutputModel>();
            CreateMap<RoomOutputModel, RoomOutput>();
        }
    }
}
