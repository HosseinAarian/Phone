namespace Phone.Domain.Contract.DTOs;

public record PhoneDetailDTO
{
    public int Id { get; set; }
    public required string Color { get; set; }
    public required string OS { get; set; }
    public required string Hard { get; set; }
    public required string Ram { get; set; }
}
