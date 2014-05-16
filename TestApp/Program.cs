

namespace TestApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MailSender;
    using MandrillMailSender;
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            string apikey = "F3oFPMyvxI2JQyEpIydqFw";
            IMailSender m = new MandrillMailSenderClass(apikey);
            m.Ping();
            bool html = false;
            Mail mm = new Mail("from", "to", "subject", "content bla", html);
            m.SendMail(mm);
        }
    }
}
