using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// The Message class serves as the abstraction layer in the Bridge design pattern. It provides
// a template for messages that can be sent using various message sending implementations.
// It contains a reference to an IMessageSender, which is the "bridge" to the implementation
// layer that actually sends the message.
public abstract class Message
{
    // Protected member for the IMessageSender interface. This allows derived classes to
    // access the messageSender for sending messages. The IMessageSender is the "bridge"
    // that separates the message abstraction from the specifics of how messages are sent.
    protected IMessageSender messageSender;

    // Constructor that allows a specific implementation of IMessageSender to be passed in.
    // This design allows for different message sending implementations to be used interchangeably
    // at runtime.
    protected Message(IMessageSender sender)
    {
        messageSender = sender;
    }

    // The Send method is declared as abstract, meaning that it must be implemented by
    // subclasses. This method will typically invoke the SendMessage method on the
    // messageSender, providing a flexible way to send messages without being coupled
    // to the details of how the messages are actually transmitted.
    public abstract void Send();
}
