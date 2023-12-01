using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

// FakeMessageSender is a stub class used to simulate the behavior of a real message sender
// in a controlled test environment. It implements the IMessageSender interface and records
// the last message sent for verification in tests.

public class FakeMessageSender : IMessageSender
{
    public string LastSentMessage { get; private set; } = string.Empty;

    // Simulates sending a message by simply recording the message details.

    public void SendMessage(string subject, string body)
    {
        LastSentMessage = $"{subject}: {body}";
    }
}

// The Tests class contains all the unit tests for the message sending functionality.

namespace bridgePatternTest
{
    public class Tests
    {
        private FakeMessageSender fakeEmailSender;
        private FakeMessageSender fakeSmsSender;

        // SetUp method runs before each test to initialize the test environment.

        [SetUp]
        public void Setup()
        {
            fakeEmailSender = new FakeMessageSender();
            fakeSmsSender = new FakeMessageSender();
        }

        // Tests that a UserMessage correctly uses the EmailSender to send a message.

        [Test]
        public void UserMessage_SendEmail_CallsEmailSender()
        {
            var message = new UserMessage("Test", "This is a test message", fakeEmailSender);
            message.Send();
            Assert.IsNotNull(fakeEmailSender.LastSentMessage);
            Assert.That(fakeEmailSender.LastSentMessage, Is.EqualTo("Test: This is a test message"));
        }

        // Tests that a UserMessage correctly uses the SmsSender to send an SMS message.

        [Test]
        public void UserMessage_SendSMS_CallsSmsSender()
        {
            var message = new UserMessage("Test", "This is a test SMS message", fakeSmsSender);
            message.Send();
            Assert.IsNotNull(fakeSmsSender.LastSentMessage);
            Assert.That(fakeSmsSender.LastSentMessage, Is.EqualTo("Test: This is a test SMS message"));
        }

        // Tests that a SystemMessage correctly uses the EmailSender for sending messages.

        [Test]
        public void SystemMessage_SendEmail_CallsEmailSender()
        {
            var message = new SystemMessage("System Test Message", fakeEmailSender);
            message.Send();
            Assert.IsNotNull(fakeEmailSender.LastSentMessage);
            Assert.IsTrue(fakeEmailSender.LastSentMessage.Contains("System Test Message"));
        }

        // Tests that a SystemMessage correctly uses the SmsSender for sending SMS messages.

        [Test]
        public void SystemMessage_SendSMS_CallsSmsSender()
        {
            var message = new SystemMessage("System Test SMS", fakeSmsSender);
            message.Send();
            Assert.IsNotNull(fakeSmsSender.LastSentMessage);
            Assert.IsTrue(fakeSmsSender.LastSentMessage.Contains("System Test SMS"));
        }

        // Verifies that different message types use the correct sender implementation.

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