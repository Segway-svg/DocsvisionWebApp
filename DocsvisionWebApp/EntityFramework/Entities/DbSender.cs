namespace DocsvisionWebApp.EntityFramework.Entities;

public class DbSender
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<DbEmail> Emails { get; set; } = new List<DbEmail>();
}