using AutoMapper;
using Phone.Application.Contract.CommandsQueries.Brands;
using Phone.Application.Contract.CommandsQueries.Phones;
using Phone.Domain.Contract.DTOs;

namespace Phone.Application.Contract.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BrandDTO, GetBrandQueryResponse>().ReverseMap();
        CreateMap<PhoneDTO, GetPhoneQueryResponse>().ReverseMap();
        CreateMap<PhoneDetailDTO, GetPhoneDetailQueryResponse>().ReverseMap();
        CreateMap<PhoneDTO, GetAllPhoneQueryResponse>().ReverseMap();
        CreateMap<PhoneDetailDTO, GetAllPhoneDetailQueryResponse>().ReverseMap();
    }
}
