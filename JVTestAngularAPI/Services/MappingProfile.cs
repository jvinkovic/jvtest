using AutoMapper;
using Services.Models;

namespace Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.Models.RentModel, RentModel>();
            CreateMap<Data.Models.SkiModel, SkiModel>().ReverseMap();
            CreateMap<RentModelBase, Data.Models.RentModel>();
        }
    }
}
