class Program
{
    static void Main(string[] args)
    {
        ILogger logger = new ConsoleLogger();
        IMessageSender emailSender = new EmailSender();
        IMessageSender smsSender = new SmsSender();

        Message email = new UserMessage("Hello", "This is an email message!", emailSender);
        email.Send();

        Message sms = new UserMessage("Hello", "This is a SMS message!", smsSender);
        sms.Send();

        Message systemMessage = new SystemMessage("Server Restart Scheduled", emailSender);
        systemMessage.Send();
    }
}
