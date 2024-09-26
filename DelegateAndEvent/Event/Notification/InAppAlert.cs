using Event.CustomEventArgs;

namespace Event.Notification;

public class InAppAlert
{
    public void OnMessageReceived(object source, MessageEventArgs e)
    {
        if (source is MessageService service) // use source object to handle different publisher instances
        {
            Console.WriteLine($"In-app alert: New message from {e.Sender}: {e.Message}");
        }
    }
}
