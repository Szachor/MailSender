﻿
namespace MailSender
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public interface MailInterface
    {
        bool AddRecipient(string recipient);
    }
}
