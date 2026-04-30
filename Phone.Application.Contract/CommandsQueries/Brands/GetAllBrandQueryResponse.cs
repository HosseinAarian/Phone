using Phone.Domain.Contract.DTOs;

namespace Phone.Application.Contract.CommandsQueries.Brands;

public record GetAllBrandQueryResponse
{
    public List<BrandDTO> Brands { get; set; }
}
