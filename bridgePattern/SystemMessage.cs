using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// The SystemMessage class represents a specialized type of message within the system.
// It extends the Message abstract class, making it a specific kind of message that,
// for example, might be used for system notifications or alerts.
public class SystemMessage : Message
{
    // The messageContent field holds the main text content of the system message.
    private string messageContent;

    // The constructor for SystemMessage takes a string representing the message content
    // and an IMessageSender implementation. It passes the IMessageSender to the base class
    // constructor to maintain the bridge to the message sending implementation.
    public SystemMessage(string content, IMessageSender sender) : base(sender)
    {
        messageContent = content;
    }

    // The Send method is overridden here to define the specific behavior for sending
    // a system message. This is where the message content is formatted and passed
    // to the message sending implementation via the messageSender's SendMessage method.
    public override void Send()
    {
        // The fullMessage variable formats the system message content with a prefix
        // to indicate that it's a system-level message. This helps differentiate it
        // from other types of messages when it is sent or logged.
        string fullMessage = $"[System] {messageContent}";

        // The SendMessage method of the messageSender (the bridge) is called with
        // a generic 'System Alert' subject and the formatted full message as the body.
        // The actual sending logic is encapsulated within the messageSender.
        messageSender.SendMessage("System Alert", fullMessage);
    }
}
