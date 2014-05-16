// <copyright file="MandrillMailSenderTest.cs" company="CMM">
//     CMM. All rights reserved.
// </copyright>
// <author>CMM</author>
namespace UnitTestForMandrillMailSender
{
    using System;
    using System.Diagnostics;
    using MailSender;
    using MandrillMailSender;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Klasa testująca MandrillMailSednerClass
    /// </summary>
    [TestClass]
    public class MandrillMailSenderTest
    {
        /// <summary>
        /// Poprawny mail na podstawie, którego przeprowadzamy testy.
        /// </summary>
        private static Mail mail;

        /// <summary>
        /// Obiekt klasy MandrillMailSenderClass, którą testujemy.
        /// </summary>
        private static MandrillMailSenderClass sender;

        /// <summary>
        /// Używany przez nas "testowy" apikey w testach.
        /// Używany klucz nie wysyła maili, ale jest używany do zwracania odpowiedzi z serwera.
        /// </summary>
        private static string apiKey;

        /// <summary>
        /// Inicjalizacja klasy.
        /// Stworzenie przykładowy obiekt maila, testowego apikey oraz stworzenie na jego podstawie
        /// obiekt klasy MandrillMailSenderClass
        /// </summary>
        /// <param name="context">Context klasy testującej.</param>
        [ClassInitialize]
        public static void IterationClassInitialize(TestContext context)
        {
            mail = new Mail("testmailsender4@gmail.com", "testmailsender4@gmail.com", "Test mail", "Test body", false);
            apiKey = "Yt2RkGJrlFG6LD3BanmsWw";
            sender = new MandrillMailSenderClass(apiKey);
        }

        /// <summary>
        /// Test metody MandrillMailSenderClass.SendersList().
        /// Sprawdzenie czy status w odpowiedzi nie jest równy 'error'.
        /// </summary>
        [TestMethod]
        public void TestMandrillSendersList()
        {
            Response result = (Response)sender.SendersList();
            Debug.WriteLine(result.ToString());
            Assert.AreNotEqual("error", result.status);
        }

        /// <summary>
        /// Test metody MandrillMailSenderClass.SendMail(Mail).
        /// Sprawdzenie czy status w odpowiedzi równy jest 'sent'.
        /// </summary>
        [TestMethod]
        public void TestMandrillMailSendRecject()
        {
            Response result = (Response)sender.SendMail(mail);
            Debug.WriteLine(result.ToString());
            Assert.AreEqual("sent", result.status);
        }

        /// <summary>
        /// Test metody MandrillMailSenderClass.TestKey(Mail).
        /// Sprawdzenie czy odpowiedź zwrotna jest równa true.
        /// </summary>
        [TestMethod]
        public void TestApiKey()
        {
            bool result = sender.TestKey("Yt2RkGJrlFG6LD3BanmsWw");
            Debug.WriteLine(result.ToString());
            Assert.AreEqual(true, result);
        }
    }
}