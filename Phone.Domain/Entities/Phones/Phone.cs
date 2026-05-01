namespace Phone.Domain.Entities.Phones;

public class Phone
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }

    public List<PhoneDetail> PhoneDetails { get; set; } = new List<PhoneDetail>();
}
