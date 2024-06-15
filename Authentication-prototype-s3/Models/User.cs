namespace Authentication_prototype_s3.Models;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<Country> Countries { get; } = new List<Country>();
}
