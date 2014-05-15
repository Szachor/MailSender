using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender;
using Newtonsoft.Json.Linq;

namespace MandrillMailSender
{
    public class Response : ResponseInterface
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

        #region Properties
        public JObject json
        {
            get { return _json; }
        }

        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string message
        {
            get { return _message; }
            set { _message = value; }
        }
        public string reject_reason
        {
            get { return _reject_reason; }
            set { _reject_reason = value; }
        }
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string ping
        {
            get { return _ping; }
            set { _ping = value; }
        }

        #endregion

        #region Constructors
        public Response()
        {
        }
        public Response(JObject json)
        {
            _json = json;
            _status = json["response"]["status"].ToString();
            _name = json["name"].ToString();
            _message = json["message"].ToString();
            _reject_reason = json["reject_reason"].ToString();
        }
        #endregion

        #region Methods
        public string ToString()
        {
            string s = "";
            if (this._status != null){
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
            if (s.Length == 0 && json != null) 
            {
                return json.ToString();
            }
            return s;
        }
        #endregion
    }
}
