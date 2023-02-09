namespace DocsvisionWebApp;

public class CreateEmailRequest
{
    public string Name { get; set; }
    public string Receiver { get; set; }
    public string Sender { get; set; }
    public string Content { get; set; }
}