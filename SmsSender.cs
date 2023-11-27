using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SmsSender : IMessageSender
{
    public void SendMessage(string subject, string body)
    {
        // Logic to send SMS
        Console.WriteLine($"Sending SMS: Message: {body}");
    }
}
