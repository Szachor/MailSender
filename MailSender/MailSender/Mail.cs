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


        private List<Address> _tos;
        private List<Attachments>_attachments;
        private String _content;
        private String _subject;
        private bool html;

        #region Properties
        public List<Address> to
        {
            get { return this._tos; }
            set { this._tos = value; }
        }
        public List<Address> attachments
        {
            get { return this._tos; }
            set { this._tos = value; }
        }
        public string text
        {
            get { return this._content; }
            set { this._content = value; }
        }
        public string subject
        {
            get { return this._subject; }
            set { this._subject = value; }
        }
        #endregion
        public class Address
        {
            private string _email;
            public string email
            {
                get { return this._email; }
                set { this._email = value; }
            }
            public Address(string email)
            {
                this._email = email;
            }
        }
        public class Attachments
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="to"></param>
        /// <param name="_subject"></param>
        /// <param name="_content"></param>
        /// <param name="html"></param>
        public Mail(String to, String subject, String content = "", bool html = false) : this(subject, content, html)
        {
            _tos = new List<Address>();
            _attachments = new List<Attachments>();
            _tos.Add(new Address(to));
        }

        public Mail(String subject, String content = "", bool html = false)
        {
            this._subject = subject;
            this._content = content;
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
