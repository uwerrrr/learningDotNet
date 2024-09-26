using Event.CustomEventArgs;

namespace Event.Notification;

public class EmailNotification
{
    public void OnMessageReceived(object source, MessageEventArgs e)
    {
        Console.WriteLine($"Email Notification: New message from {e.Sender}: {e.Message}");
    }
}