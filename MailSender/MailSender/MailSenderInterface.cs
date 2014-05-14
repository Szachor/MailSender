using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public interface MailSenderInterface
    {
        Object SendMail(Mail mail);
        Object SendTestMail(Mail m);
        Object TestKey();
        Object SendersList();
    }
}
