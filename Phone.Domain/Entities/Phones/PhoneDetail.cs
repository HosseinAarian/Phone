namespace Phone.Domain.Entities.Phones;

public class PhoneDetail
{
    public int Id { get; set; }
    public required string Color { get; set; }
    public required string OS { get; set; }
    public required string Hard { get; set; }
    public required string Ram { get; set; }

	public int PhoneId { get; set; }
	public Phone Phone { get; set; }
}
