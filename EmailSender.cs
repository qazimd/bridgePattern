using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EmailSender : IMessageSender
{
    public void SendMessage(string subject, string body)
    {
        // Logic to send email
        Console.WriteLine($"Sending Email: Subject: {subject}, Body: {body}");
    }
}
