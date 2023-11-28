using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SystemMessage : Message
{
    private string messageContent;

    public SystemMessage(string content, IMessageSender sender) : base(sender)
    {
        messageContent = content;
    }

    public override void Send()
    {
        string fullMessage = $"[System] {messageContent}";
        messageSender.SendMessage("System Alert", fullMessage);
    }
}
