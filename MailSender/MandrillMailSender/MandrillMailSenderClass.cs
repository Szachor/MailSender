using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender;
using Newtonsoft.Json.Linq;
using RestSharp;
using Newtonsoft.Json.Serialization;
namespace MandrillMailSender
{
    public class MandrillMailSenderClass : MailSenderInterface
    {
        #region Fields
        private string url;
        private string apikey;
        #endregion

        #region Properties
        public string Url
        {
            get { return this.url; }
            set { this.url = value; }
        }
        public string Apikey
        {
            get { return this.apikey; }
            set { this.apikey = value; }
        }
        #endregion
        #region JsonSerializer
        #endregion

        public MandrillMailSenderClass(String apikey)
        {
            this.apikey = apikey;
            url = "https://mandrillapp.com/api/1.0/";
        }

        public bool SendMail(Mail mail) { return false; }
        public bool SendTestMail() { return false; }
        public bool TestKey() { return false; }

        public Object SendersList()
        {
            //string urlPost = url + "senders/list.json";
            string post="";
            RestRequest request = new RestRequest("senders/list.json");
            request.RequestFormat = DataFormat.Json;
            //request.AddBody(new { key = this.apikey });
            
            /*post += '{';
            post += "\"key\":";
            post += '"';
            post += apikey;
            post += '"';
            post += '}';
            */
            //request.AddBody(post);
            //return GetJsonResponse(urlPost, request);
            request.AddObject(new { key = this.apikey });
            return GetJsonResponse(request);
        }
        private JObject GetJsonResponse(RestRequest request)
        {
            RestClient client = new RestClient(url);
            IRestResponse response = client.Execute(request);
            response.Content = "{\"list\":" + response.Content + '}';
            JObject json = JObject.Parse(response.Content);
            return json;
        }

    }
}