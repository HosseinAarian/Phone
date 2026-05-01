using AutoMapper;
using Phone.Application.Contract.CommandsQueries.Brands;
using Phone.Domain.Contract.DTOs;

namespace Phone.Application.Contract.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BrandDTO, GetBrandQueryResponse>().ReverseMap();
    }
}
