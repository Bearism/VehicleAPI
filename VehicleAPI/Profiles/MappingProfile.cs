using AutoMapper;
using VehicleAPI.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BoatDTO, Boat>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

    }
}