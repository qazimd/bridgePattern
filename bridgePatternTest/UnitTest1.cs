using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

// Fake implementations for testing
public class FakeMessageSender : IMessageSender
{
    public string LastSentMessage { get; private set; } = string.Empty;

    public void SendMessage(string subject, string body)
    {
        LastSentMessage = $"{subject}: {body}";
    }
}


namespace bridgePatternTest
{
    public class Tests
    {
        private FakeMessageSender fakeEmailSender;
        private FakeMessageSender fakeSmsSender;

        [SetUp]
        public void Setup()
        {
            fakeEmailSender = new FakeMessageSender();
            fakeSmsSender = new FakeMessageSender();
        }

        [Test]
        public void UserMessage_SendEmail_CallsEmailSender()
        {
            var message = new UserMessage("Test", "This is a test message", fakeEmailSender);
            message.Send();
            Assert.IsNotNull(fakeEmailSender.LastSentMessage);
            Assert.That(fakeEmailSender.LastSentMessage, Is.EqualTo("Test: This is a test message"));
        }

        [Test]
        public void UserMessage_SendSMS_CallsSmsSender()
        {
            var message = new UserMessage("Test", "This is a test SMS message", fakeSmsSender);
            message.Send();
            Assert.IsNotNull(fakeSmsSender.LastSentMessage);
            Assert.That(fakeSmsSender.LastSentMessage, Is.EqualTo("Test: This is a test SMS message"));
        }

        [Test]
        public void SystemMessage_SendEmail_CallsEmailSender()
        {
            var message = new SystemMessage("System Test Message", fakeEmailSender);
            message.Send();
            Assert.IsNotNull(fakeEmailSender.LastSentMessage);
            Assert.IsTrue(fakeEmailSender.LastSentMessage.Contains("System Test Message"));
        }

        [Test]
        public void SystemMessage_SendSMS_CallsSmsSender()
        {
            var message = new SystemMessage("System Test SMS", fakeSmsSender);
            message.Send();
            Assert.IsNotNull(fakeSmsSender.LastSentMessage);
            Assert.IsTrue(fakeSmsSender.LastSentMessage.Contains("System Test SMS"));
        }

        [Test]
        public void Message_UsesCorrectSender()
        {
            var emailMessage = new UserMessage("Email Test", "Email body", fakeEmailSender);
            var smsMessage = new UserMessage("SMS Test", "SMS body", fakeSmsSender);

            emailMessage.Send();
            smsMessage.Send();

            Assert.That(fakeEmailSender.LastSentMessage, Is.EqualTo("Email Test: Email body"));
            Assert.That(fakeSmsSender.LastSentMessage, Is.EqualTo("SMS Test: SMS body"));
        }
    }
}