
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
    public class Mail : MailInterface
    {


        #region Properties
        private List<Address> _tos;
        private List<Attachments> _attachments;
        private string _content;
        private string _subject;
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
        /// <summary>
        /// 
        /// </summary>
        public class Address
        {
            private string _email;
            /// <summary>
            /// 
            /// </summary>
            public string email
            {
                get { return this._email; }
                set { this._email = value; }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="email"></param>
            public Address(string email)
            {
                this._email = email;
            }
        }
        #endregion

        #region class Attachments
        /// <summary>
        /// 
        /// </summary>
        public class Attachments
        {

        }
        #endregion


        #region constructors
        public Mail(string to, string subject, string content = "", bool html = false)
        {
            this._tos = new List<Address>();
            this._attachments = new List<Attachments>();
            this._tos.Add(new Address(to));
            this._subject = subject;
            this._content = content;
            this.html = html;
        }
        #endregion

        #region methods
        public bool AddRecipient(string recipient)
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
