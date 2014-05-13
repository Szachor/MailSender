using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender;
using RestSharp;


namespace MandrillMailSender
{
    public class MandrillMailSenderClass : MailSenderInterface
    {
        public MandrillMailSenderClass(String apikey);
        public bool SendMail(Mail mail);
        public bool SendTestMail();
        public bool TestKey();

        private string MandrillUrl = "https://mandrillapp.com/api/1.0/";

    }
}
