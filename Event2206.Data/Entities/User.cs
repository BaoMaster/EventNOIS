namespace Event2206.Data.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? CompanyName { get; set; }
    public DateTime Created { get; set; }
    public Boolean isNOISCustomer { get; set; }
}
