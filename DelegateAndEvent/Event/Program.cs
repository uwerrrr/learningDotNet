using Event.Notification;

namespace Event
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the message service (publisher)
            var messageService = new MessageService();

            // Create event handlers (subscribers)
            var emailNotification = new EmailNotification();
            var databaseLogger = new DatabaseLogger();
            var inAppAlert = new InAppAlert();

            // Step 6: Subscribe handlers to the event
            messageService.OnMessageReceived += emailNotification.OnMessageReceived;
            messageService.OnMessageReceived += databaseLogger.OnMessageReceived;
            messageService.OnMessageReceived += inAppAlert.OnMessageReceived;
            
            // Step 7: Trigger the event by simulating a new message
            messageService.ReceiveMessage("this is the message", "sender name");
            /* will execute all subscribed methods:
                - messageService.ReceiveMessage itself
                - emailNotification.OnMessageReceived
                - databaseLogger.OnMessageReceived
                - inAppAlert.OnMessageReceived
            */
            
            // Bonus: Unsubscribe an event handler
            messageService.OnMessageReceived -= inAppAlert.OnMessageReceived;

            // Bonus: Trigger the event again to see the result
            messageService.ReceiveMessage("this is second message", "sender name 2");
        }
    }
}