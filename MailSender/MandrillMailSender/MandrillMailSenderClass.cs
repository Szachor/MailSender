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

        public bool SendMail(Mail mail)
        {
            RestRequest request = new RestRequest("/messages/send.json");
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "json");
            //request.AddObject(new { key = this.apikey });
            string json = @"{
    ""key"": ""F3oFPMyvxI2JQyEpIydqFw"",
    ""message"": {
        ""text"": ""Example text content"",
        ""subject"": ""example subject"",
        ""to"": [
            {
                ""email"": ""m.farfulowska@gmail.com""
            }
        ],
        ""attachments"": [
            {
            }
        ]
    }
}";

            string[,] array2D = new string[,] { { "text", "Example text content" }, 
            { "subject", "example subject", }, 
            { "from_name", "Example Name" }, { "to", "m.farfulowska@gmail.com" } };
            JObject j = JObject.Parse(json);

            //request.AddBody(request.JsonSerializer.Serialize(new { key = this.Apikey, message = j }));
            request.AddParameter("key", this.Apikey);
            //request.AddParameter("message", array2D);
            request.AddParameter("subscriber", "m.farfulowska@gmail.com");
            request.AddParameter("subject", "jakis temat");
            request.AddParameter("text", "tutaj tresc");

            //request.AddBody(new { key = this.apikey, message = j });
            //request.AddParameter("key", apikey);
            //request.AddParameter("text", "Example text content");
            //request.AddParameter("subject", "example subject");
            //request.AddParameter("to", "m.farfulowska@gmail.com");                      
            
            RestClient client = new RestClient(url);
            IRestResponse response = client.Execute(request);
            Console.WriteLine("request");
            Console.WriteLine(response.Content);
            return true;
        }

        public bool SendTestMail() { return false; }
        public bool TestKey() { return false; }
        
        public Object SendersList()
        {
            string post = "";
            RestRequest request = new RestRequest("senders/list.json");
            request.RequestFormat = DataFormat.Json;
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