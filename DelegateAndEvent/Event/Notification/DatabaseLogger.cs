using Event.CustomEventArgs;

namespace Event.Notification;

public class DatabaseLogger
{
    //Create a method to log the message to the database
    public void OnMessageReceived(object source, MessageEventArgs e)
    {
        Console.WriteLine($"Logging to database: {e.Message} from {e.Sender}");
    }
}
