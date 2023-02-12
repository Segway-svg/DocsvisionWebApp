namespace DocsvisionClientServer.Responses;

public class CreateReceiverResponse
{
    public Guid? Id { get; set; }
    public bool IsSuccess { get; set; }
    public List<string> Errors { get; set; }
}