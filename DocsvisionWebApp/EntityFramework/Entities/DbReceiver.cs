namespace DocsvisionWebApp.EntityFramework.Entities;

public class DbReceiver
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<DbEmailReceiver> EmailsReceivers { get; set; } = new List<DbEmailReceiver>();
}
