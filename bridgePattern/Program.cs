using System;

class Program
{
    // The Main method is the entry point of the application.
    static void Main(string[] args)
    {
        // Instantiating the ConsoleLogger class, which implements the ILogger interface.
        // This logger will be used throughout this program to log messages to the console.
        ILogger logger = new ConsoleLogger();

        // Creating instances of EmailSender and SmsSender, both of which implement the
        // IMessageSender interface. This demonstrates the flexibility of the bridge pattern
        // where the implementation can be switched easily without changing the client code.
        IMessageSender emailSender = new EmailSender();
        IMessageSender smsSender = new SmsSender();

        // Creating a UserMessage object with an email content and associating it with
        // an email sender implementation. This shows the decoupling of the message content
        // from the delivery mechanism.
        Message email = new UserMessage("Hello", "This is an email message!", emailSender);

        // Sending the email message. The actual sending logic is encapsulated by the EmailSender.
        email.Send();

        // Similarly, creating a UserMessage object with SMS content and associating it with
        // an SMS sender implementation.
        Message sms = new UserMessage("Hello", "This is a SMS message!", smsSender);

        // Sending the SMS message. The actual sending logic is encapsulated by the SmsSender.
        sms.Send();

        // Creating a SystemMessage object, which represents a different type of message
        // in the system, and associating it with the email sender implementation. This
        // demonstrates that various message types can utilize the same sending mechanism.
        Message systemMessage = new SystemMessage("Server Restart Scheduled", emailSender);

        // Sending the system message. Despite being a different type of message, the sending
        // process remains consistent due to the use of the bridge pattern.
        systemMessage.Send();
    }
}
