
namespace MandrillMailSender
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MailSender;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// 
    /// </summary>
    public class Response : IResponse
    {
        #region fields
        private JObject _json;

        private string _status;
        private string _name;
        private string _message;
        private string _reject_reason;
        private string _id;
        private string _ping;
        #endregion

        #region Constructors
        public Response()
        {
        }
        public Response(JObject json)
        {
            this._json = json;
            this._status = json["response"]["status"].ToString();
            this._name = json["name"].ToString();
            this._message = json["message"].ToString();
            this._reject_reason = json["reject_reason"].ToString();
        }
        #endregion

        #region Properties
        public JObject Json
        {
            get { return this._json; }
        }

        public string status
        {
            get { return this._status; }
            set { this._status = value; }
        }
        public string name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        public string message
        {
            get { return this._message; }
            set { this._message = value; }
        }
        /// <summary>
        /// reject reason
        /// </summary>
        public string reject_reason
        {
            get { return this._reject_reason; }
            set { this._reject_reason = value; }
        }
        public string id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        public string ping
        {
            get { return this._ping; }
            set { this._ping = value; }
        }

        #endregion
        
        #region Methods
        public string ToString()
        {
            string s = string.Empty;
            if (this._status != null)
            {
            s += "Status: ";
            s += this._status + '\n';
            }
            if (this._message != null)
            {
                s += "Message: ";
                s += this._message + '\n';
            }
            if (this._name != null)
            {
                s += "Name: ";
                s += this._name + '\n';
            }
            if (this._reject_reason != null)
            {
                s += "Reject_reason: ";
                s += this._reject_reason + '\n';
            }
            if (s.Length == 0 && this.Json != null) 
            {
                return this.Json.ToString();
            }
            return s;
        }
        #endregion
    }
}
