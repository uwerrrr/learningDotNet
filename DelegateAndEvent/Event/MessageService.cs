using Event.CustomEventArgs;

namespace Event;

public class MessageService
{
    //Step 1: Declare the event using EventHandler<MessageEventArgs> (generic event handler with custom args)
    public delegate void MessageEventHandler(object senderEventObj, MessageEventArgs e);
    public event MessageEventHandler OnMessageReceived;
    // same as
    public event EventHandler<MessageEventArgs> OnMessageReceived2; 
    
    
    // Method to simulate receiving a new message and raise the event
    public void ReceiveMessage(string message, string sender)
    {
        Console.WriteLine($"Message received from {sender}: {message}");

        // Step 3: Execute method that raise the event
        SendMessage(message, sender);
    }

    // Step 2: Create a method to raise the event
    public virtual void SendMessage(string message, string sender)
    {
        if (OnMessageReceived != null)
        {
            OnMessageReceived.Invoke(this, new MessageEventArgs(message, sender));
            // "this": represents the object instance that is currently executing the method.
            // In thsi case, in Program class, it refers to the instance of MessageService that is invoking the OnMessageReceived event.
        }
    }
}