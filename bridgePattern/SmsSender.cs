using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// The SmsSender class is a concrete implementation of the IMessageSender interface
// specific to sending SMS messages. This class demonstrates the flexibility of the
// Bridge pattern, allowing the abstraction layer (the Message class) to interact
// with different message sending implementations without being tightly coupled to them.
public class SmsSender : IMessageSender
{
    // SendMessage is the method responsible for implementing the logic to send an SMS.
    public void SendMessage(string subject, string body)
    {
        // In a real-world scenario, this method would include integration with an SMS
        // service provider's API to send the message. For our purposes, the
        // sending action is simulated by outputting the message to the console.
        // The Console.WriteLine method here is acting as a stand-in for the actual sending logic.
        Console.WriteLine($"Sending SMS: Message: {body}");
    }
}
