namespace Authentication_prototype_s3.Models;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid? UserId { get; set; }
    public User? User { get; set; }
}
