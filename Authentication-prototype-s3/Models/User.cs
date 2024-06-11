namespace Authentication_prototype_s3.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public ICollection<Country> Countries { get; } = new List<Country>();
}
