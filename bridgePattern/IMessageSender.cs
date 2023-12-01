using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// The IMessageSender interface establishes a contract for message-sending classes.
// Classes that implement this interface will provide specific implementations for sending messages.
public interface IMessageSender
{
    // The SendMessage method is declared with the intention that any implementing class will
    // use it to send a message with a subject and a body. The parameters 'subject' and 'body'
    // represent the two typical parts of a message. 
    void SendMessage(string subject, string body);
}
