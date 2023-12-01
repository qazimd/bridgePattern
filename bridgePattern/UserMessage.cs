using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// The UserMessage class represents a type of message intended for users, such as an email or an SMS.
// It extends the Message abstract class, utilizing the Bridge pattern to separate the message
// content (subject and body) from the method of sending (handled by IMessageSender implementations).
public class UserMessage : Message
{
    // The subject field holds the subject line of the user message. 
    // This could be used as the subject of an email or a heading in other message types.
    private string subject;

    // The body field holds the main content of the message.
    private string body;

    // The constructor for UserMessage takes the subject and body of the message, as well as
    // an implementation of IMessageSender. The IMessageSender is passed to the base class
    // (Message) constructor to facilitate the sending of the message.
    public UserMessage(string subject, string body, IMessageSender sender) : base(sender)
    {
        this.subject = subject;
        this.body = body;
    }

    // The Send method overrides the abstract Send method in the Message class.
    // It uses the SendMessage method of the IMessageSender (provided by the base class)
    // to send the message with its subject and body. This demonstrates the decoupling of the
    // message content from the message sending mechanism provided by the Bridge pattern.
    public override void Send()
    {
        messageSender.SendMessage(subject, body);
    }
}
