namespace DocsvisionClientServer.Requests;

public class CreateEmailRequest
{
    public string Name { get; set; }
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public string Content { get; set; }
}