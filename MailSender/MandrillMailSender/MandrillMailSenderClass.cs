using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender;


namespace MandrillMailSender
{
    public class MandrillMailSenderClass : MailSenderInterface
    {
        public MandrillMailSenderClass(String apikey);
    }
}
