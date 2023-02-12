namespace DocsvisionWebApp.EntityFramework.Entities;

public class DbEmail
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ReceiverId { get; set; }
    public Guid SenderId { get; set; }
    public DbSender Sender { get; set; }
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }
    public ICollection<DbEmailReceiver> EmailsReceivers { get; set; } = new List<DbEmailReceiver>();

}