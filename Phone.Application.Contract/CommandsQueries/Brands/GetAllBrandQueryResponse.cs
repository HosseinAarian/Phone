using Phone.Domain.Contract.DTOs;

namespace Phone.Application.Contract.CommandsQueries.Brands;

public class GetAllBrandQueryResponse
{
    public List<BrandDTO> Brands { get; set; }
}
