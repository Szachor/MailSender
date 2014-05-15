using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public interface MailSenderInterface
    {
        #region methods
        ResponseInterface SendMail(MailInterface mail);
        bool ping();
        bool TestKey(string apikey);
        ResponseInterface SendersList();
        #endregion

    }
}
