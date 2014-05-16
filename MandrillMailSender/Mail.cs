
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
    public class Mail : IMail
    {
        #region Fields
        private List<Address> _tos;
        private List<Attachments> _attachments;
        private string _content;
        private string _subject;
        private string _from;
        private bool html;
        #endregion

        #region constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="content"></param>
        /// <param name="html"></param>
        public Mail(string from, string to, string subject, string content = "", bool html = false)
        {
            this._tos = new List<Address>();
            this._attachments = new List<Attachments>();
            this._tos.Add(new Address(to));
            this._subject = subject;
            this._content = content;
            this._from = from;
            this.html = html;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public List<Address> to
        {
            get { return this._tos; }
            set { this._tos = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public List<Attachments> attachments
        {
            get { return this._attachments; }
            set { this._attachments = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string text
        {
            get { return this._content; }
            set { this._content = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string subject
        {
            get { return this._subject; }
            set { this._subject = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string from
        {
            get { return this._from; }
            set { this._from = value; }
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

        #region class Address
        /// <summary>
        /// 
        /// </summary>
        public class Address
        {
            private string _email;
            public Address(string email)
            {
                this._email = email;
            }            

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


        
    }
}
