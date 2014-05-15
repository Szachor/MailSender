
namespace MailSender
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface MailSenderInterface
    {
        #region methods
        ResponseInterface SendMail(MailInterface mail);
        bool Ping();
        bool TestKey(string apikey);
        ResponseInterface SendersList();
        #endregion

    }
}
