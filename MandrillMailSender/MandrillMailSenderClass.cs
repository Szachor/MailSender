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
        #region PostClass
        public class Post
        {
            string apikey;
            public string key
            {
                get { return this.apikey; }

            }
            public class Message
            {
                string send_text;
                string send_subject;

                public string text
                {
                    get { return this.send_text; }
                }
                public string subject
                {
                    get { return this.send_subject; }
                }
                public Message()
                {
                    send_text = "Test";
                    send_subject = "Test";
                }
            }
            Message send_message;
            public Message message 
            {
                get { return this.send_message; }
                set { this.send_message = value; }
            }
            string[] list;
            public class To
            {
                private string _email;
                private string _name;
                public string email
                {
                    get { return this._email; }
                }
                public string name
                {
                    get { return this._name; }
                }
            }
            public string[] to
            {
                get { return this.list; }
            }

            public Post(MandrillMailSenderClass mms)
            {
                send_message = new Message();
                apikey = mms.apikey;
                list = new string[10];
                for(int i=0;i<10;i++){
                    list[i]="0"+i;
                }
            }

        };
        #endregion

        public MandrillMailSenderClass(String apikey)
        {
            this.apikey = apikey;
            url = "https://mandrillapp.com/api/1.0/";
        }

        public Object SendMail(Mail mail) 
        {

            RestRequest request = new RestRequest("messages/send.json", Method.POST);
            request.JsonSerializer = new MyJsonSerializer();
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { key = apikey, message = mail });
            return GetJsonResponse(request);
        }
        public Object SendTestMail(Mail m) 
        {
            return true;
        }
        public Object TestKey() { return false; }

        public Object SendersList()
        {
            string post="";
            RestRequest request = new RestRequest("senders/list.json", Method.POST);
            request.JsonSerializer = new MyJsonSerializer();
            //MyJsonSerializer serializer = new MyJsonSerializer();
            request.RequestFormat = DataFormat.Json;
            List<String> s = new List<String>();
            s.Add("asdf");
            s.Add("asdf123123");
            //request.AddObject(new { to = new { email = "testmailsender4@gmail.com" } });
            //request.AddObject(new { key = this.apikey });
            //request.AddObject(new Mail("Test", "Test", "Test"));
            Mail m = new Mail("Test", "Test", "Test");
            //request.AddObject(new { key = napraw(m) });
            request.AddBody(new { key = apikey, message = m });
            //request.AddParameter("\"key\"", serializer.Serialize(this.apikey), ParameterType.RequestBody);
            //request.AddParameter("key", serializer.Serialize(m), ParameterType.RequestBody);
            //var json = Json
            //string json = JsonConvert.SerializeObject(product);
            //request.AddParameter("application/json; charset=utf-8", new Post(this), ParameterType.RequestBody);
            return GetJsonResponse(request);
        }
        public String napraw(Mail m)
        {
            MyJsonSerializer serializer = new MyJsonSerializer();
            String result = apikey;
            result += "\" ,";
            result += serializer.Serialize(m);
            result += ",\"smiec\":\"smiec";
            return result;
        }

        private JObject GetJsonResponse(RestRequest request)
        {
            RestClient client = new RestClient(url);
            IRestResponse response = client.Execute(request);
            response.Content = "{\"response\":" + response.Content + '}';
            JObject json = JObject.Parse(response.Content);
            return json;
        }

    }
}