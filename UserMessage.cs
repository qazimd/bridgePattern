using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserMessage : Message
{
    private string subject;
    private string body;

    public UserMessage(string subject, string body, IMessageSender sender) : base(sender)
    {
        this.subject = subject;
        this.body = body;
    }

    public override void Send()
    {
        messageSender.SendMessage(subject, body);
    }
}
