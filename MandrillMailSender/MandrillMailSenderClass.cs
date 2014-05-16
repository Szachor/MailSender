

namespace MandrillMailSender
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MailSender;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;
    using RestSharp;
    using RestSharp.Serializers;
    /// <summary>
    /// 
    /// </summary>
    public class MandrillMailSenderClass : IMailSender
    {
        #region Fields
        public static string url;
        private string apikey;
        #endregion

        #region Constructors
        /// <summary>
        /// konstruktor
        /// </summary>
        /// <param name="apikey">Api key</param>
        public MandrillMailSenderClass(string apikey)
        {
            this.apikey = apikey;
            url = "https://mandrillapp.com/api/1.0/";
        }
        #endregion

        #region Properties
        public string Apikey
        {
            get { return this.apikey; }
            set { this.apikey = value; }
        }
        #endregion

        #region methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        public IResponse SendMail(IMail mail) 
        {
            RestRequest request = new RestRequest("messages/send.json", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { key = this.apikey, message = mail });
            return GetResponse(request);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Ping()
        {
            return this.TestKey(this.apikey);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apikey"></param>
        /// <returns></returns>
        public bool TestKey(string apikey)
        {
            RestRequest request = new RestRequest("users/ping2.json", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { key = this.apikey });
            Response response = (Response)GetResponse(request);
            if ("PONG!".CompareTo(response.ping) == 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IResponse SendersList()
        {
            RestRequest request = new RestRequest("senders/list.json", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { key = this.apikey });
            return GetResponse(request);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static IResponse GetResponse(RestRequest request)
        {
            RestClient client = new RestClient(url);
            IRestResponse response = client.Execute(request);
            if (response.Content[0] != '[')
            {
                response.Content = '[' + response.Content + ']';
            }
            // response.Content = "{\"response\":" + response.Content + '}';
            // JObject Json = JObject.Parse(response.Content);
            List<Response> r = JsonConvert.DeserializeObject<List<Response>>(response.Content);
            // return new Response(Json);
            return r.Last();
        }
        #endregion

    }
}