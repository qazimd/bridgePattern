using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Message
{
    protected IMessageSender messageSender;

    protected Message(IMessageSender sender)
    {
        messageSender = sender;
    }

    public abstract void Send();
}
