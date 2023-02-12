namespace DocsvisionWebApp.EntityFramework.Entities;

public class DbEmailReceiver
{
    public Guid Id { get; set; }
    public Guid EmailId { get; set; }
    public Guid ReceiverId { get; set; }
}