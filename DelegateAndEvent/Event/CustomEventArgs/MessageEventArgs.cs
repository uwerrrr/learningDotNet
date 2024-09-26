namespace Event.CustomEventArgs;

public class MessageEventArgs : EventArgs
// custom event arguments
{
    public string Message { get; set; }
    public string Sender { get; set; }

    public MessageEventArgs(string message, string sender)
    {
        Message = message;
        Sender = sender;
    }
}
