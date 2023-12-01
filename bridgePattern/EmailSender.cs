using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// The EmailSender class is a concrete implementation of the IMessageSender interface.
// Its role is to handle the sending of messages via email. While this class currently
// does not send real emails and instead simulates the process by writing to the console.
public class EmailSender : IMessageSender
{
    // The SendMessage method is responsible for sending an email with the given subject and body.
    // In a real-world application, this method would contain logic to connect to an email server
    // and send the email. For our purposes, this method simply prints the email content
    // to the console, which acts as a placeholder for the actual sending operation.
    public void SendMessage(string subject, string body)
    {
        // This line simulates the sending of an email by outputting the subject and body to the console.
        // In a production environment, this would be replaced with a call to an email service's API.
        // For example, you could use SMTP protocol or an email service like SendGrid to send the email.
        Console.WriteLine($"Sending Email: Subject: {subject}, Body: {body}");
    }
}