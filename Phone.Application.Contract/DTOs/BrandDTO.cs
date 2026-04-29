namespace Phone.Application.Contract.DTOs;

public class BrandDTO
{
    public short Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
}
