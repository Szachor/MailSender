using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    /// <summary>
    /// 
    /// </summary>
    public class Mail
    {
        private List<String> tos { get; set; }
        private String content { get; set; }
        private String subject { get; set; }
        private bool html { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="content"></param>
        /// <param name="html"></param>
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
