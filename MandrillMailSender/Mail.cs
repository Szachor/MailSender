using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public class Mail : MailInterface
    {


        #region Properties
        private List<Address> _tos;
        private List<Attachments> _attachments;
        private String _content;
        private String _subject;
        private bool html;
        #endregion

        #region Properties
        public List<Address> to
        {
            get { return this._tos; }
            set { this._tos = value; }
        }
        public List<Attachments> attachments
        {
            get { return this._attachments; }
            set { this._attachments = value; }
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

        #region class Address
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
        #endregion

        #region class Attachments
        public class Attachments
        {

        }
        #endregion

        #region constructors
        public Mail(String to, String subject, String content = "", bool html = false)
        {
            _tos = new List<Address>();
            _attachments = new List<Attachments>();
            _tos.Add(new Address(to));
            this._subject = subject;
            this._content = content;
            this.html = html;
        }
        #endregion

        #region methods
        public bool AddRecipient(String recipient)
        {
            return true;
        }
        public bool AddAtachment()
        {
            return true;
        }
        #endregion
    }
}
