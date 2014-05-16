
namespace MailSender
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMailSender
    {
        #region methods
        IResponse SendMail(IMail mail);
        bool Ping();
        bool TestKey(string apikey);
        IResponse SendersList();
        #endregion

    }
}
