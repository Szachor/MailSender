using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public interface MailSenderInterface
    {
        public MailSenderInterface(string apikey);
        public bool SendMail(Mail mail);
        public bool SendTestMail();
        public bool TestKey();
    }
}
