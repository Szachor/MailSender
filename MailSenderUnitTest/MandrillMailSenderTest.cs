
namespace UnitTestForMandrillMailSender
{
    using System;
    using System.Diagnostics;
    using MailSender;
    using MandrillMailSender;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class MandrillMailSenderTest
    {
        private static TestContext url;
        private static Mail mail;
        private static MandrillMailSenderClass sender;
        private static string apiKey;

        [ClassInitialize()]
        public static void IterationClassInitialize(TestContext context)
        {
            mail = new Mail("testmailsender4@gmail.com", "testmailsender4@gmail.com", "Test mail", "Test body", false);
            apiKey = "Yt2RkGJrlFG6LD3BanmsWw";
            sender = new MandrillMailSenderClass(apiKey);
        }
        [TestMethod]
        public void TestMandrillSendersList()
        {
            Response result = (Response)sender.SendersList();
            Debug.WriteLine(result.ToString());
            Assert.AreNotEqual("error", result.status);
        }
        [TestMethod]
        public void TestMandrillMailSendRecject()
        {
            Response result = (Response)sender.SendMail(mail);
            Debug.WriteLine(result.ToString());
            Assert.AreEqual("recject", result.status);
        }
        [TestMethod]
        public void TestApiKey()
        {
            bool result = sender.TestKey("Yt2RkGJrlFG6LD3BanmsWw");
            Debug.WriteLine(result.ToString());
            Assert.AreEqual(true, result);
        }
    }
}