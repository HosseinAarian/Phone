namespace Phone.Domain.Contract.DTOs;

public record PhoneDTO
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }

    public List<PhoneDetailDTO> PhoneDetails { get; set; } = new List<PhoneDetailDTO>();
}

