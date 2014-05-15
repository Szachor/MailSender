using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender;
using MandrillMailSender;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string apikey = "F3oFPMyvxI2JQyEpIydqFw";
            MailSenderInterface m = new MandrillMailSenderClass(apikey);
            m.TestKey();
            bool html = false;
            Mail mm = new Mail("to", "content bla", html);
            m.SendMail(mm);
        }
    }
}
