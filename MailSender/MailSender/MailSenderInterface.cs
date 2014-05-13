using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public interface MailSenderInterface
    {
        bool SendMail(Mail mail);
        bool SendTestMail();
        bool TestKey();
        Object SendersList();
    }
}
