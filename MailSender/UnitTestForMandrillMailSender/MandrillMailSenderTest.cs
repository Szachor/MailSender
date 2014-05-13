using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MandrillMailSender;
using MailSender;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
namespace UnitTestForMandrillMailSender
{
    [TestClass]
    public class MandrillMailSenderTest
    {
        private static TestContext url;
        private static Mail mail;
        private static MandrillMailSenderClass sender;
        private static string apiKey;

        [ClassInitialize()]
        public static void iterationClassInitialize(TestContext context)
        {
            mail = new Mail("Test mail", "Test body", false);
            apiKey = "F3oFPMyvxI2JQyEpIydqFw";
            sender = new MandrillMailSenderClass(apiKey);
        }
        [TestMethod]
        public void TestMandrillSendersList()
        {
            JObject result = (JObject)sender.SendersList();
            Debug.WriteLine(result.ToString());
            Assert.AreNotEqual("error", result["status"]);
        }
    }
}
