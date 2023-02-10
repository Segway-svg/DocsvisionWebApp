namespace DocsvisionWebApp.EntityFramework.Entities;

public class DbEmailSender
{
    public Guid Id { get; set; }
    public Guid EmailId { get; set; }
    public Guid SenderId { get; set; }
}