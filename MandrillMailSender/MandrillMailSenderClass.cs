using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender;
using Newtonsoft.Json.Linq;
using RestSharp;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RestSharp.Serializers;
using Newtonsoft.Json;

namespace MandrillMailSender
{
    public class MandrillMailSenderClass : MailSenderInterface
    {
        #region Fields
        static public string url;
        private string apikey;
        #endregion

        #region Properties
        public string Apikey
        {
            get { return this.apikey; }
            set { this.apikey = value; }
        }
        #endregion

        #region Constructors
        public MandrillMailSenderClass(String apikey)
        {
            this.apikey = apikey;
            url = "https://mandrillapp.com/api/1.0/";
        }
        #endregion

        #region methods
        public ResponseInterface SendMail(MailInterface mail) 
        {
            RestRequest request = new RestRequest("messages/send.json", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { key = apikey, message = mail });
            return GetResponse(request);
        }
        public bool ping()
        {
            return TestKey(this.apikey);
        }

        public bool TestKey(string apikey)
        {
            RestRequest request = new RestRequest("users/ping2.json", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { key = apikey });
            Response response = (Response)GetResponse(request);
            if ("PONG!".CompareTo(response.ping) == 0 )
            {
                return true;
            }
            return false;
        }

        public ResponseInterface SendersList()
        {
            RestRequest request = new RestRequest("senders/list.json", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { key = apikey });
            return GetResponse(request);
        }

        private static ResponseInterface GetResponse(RestRequest request)
        {
            RestClient client = new RestClient(url);
            IRestResponse response = client.Execute(request);
            if (response.Content[0] != '[')
            {
                response.Content = '['+response.Content + ']';
            }
            //response.Content = "{\"response\":" + response.Content + '}';
            //JObject json = JObject.Parse(response.Content);
            List<Response> r = JsonConvert.DeserializeObject<List<Response>>(response.Content);
            //return new Response(json);
            return r.Last();
        }
        #endregion

    }
}