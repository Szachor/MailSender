using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    class Mail
    {
        private List<String> tos;
        private String content;
        private String subject;
        private bool html;


        public Mail(String to, String subject, String content = "", bool html = false) : this(subject, content, html)
        {
            tos.Add(to);
        }

        public Mail(String subject, String content = "", bool html = false)
        {
            this.subject = subject;
            this.content = content;
            this.html = html;
        }
        public bool AddRecipient(String recipient)
        {
            return true;
        }
        public bool AddAtachment()
        {
            return true;
        }
    }
}
