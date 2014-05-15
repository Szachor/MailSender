#region License
//   Copyright 2010 John Sheehan
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 
#endregion
#region Acknowledgements
// Original MyJsonSerializer contributed by Daniel Crenna (@dimebrain)
#endregion

using System.IO;
using Newtonsoft.Json;
using MailSender;

namespace RestSharp.Serializers
{
    /// <summary>
    /// Default JSON serializer for request bodies
    /// Doesn't currently use the SerializeAs attribute, defers to Newtonsoft's attributes
    /// </summary>
    public class MyJsonSerializer : ISerializer
    {
        private readonly Newtonsoft.Json.JsonSerializer _serializer;

        /// <summary>
        /// Default serializer
        /// </summary>
        public MyJsonSerializer()
        {
            ContentType = "application/json";
            _serializer = new Newtonsoft.Json.JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Include
            };
        }

        /// <summary>
        /// Default serializer with overload for allowing custom Json.NET settings
        /// </summary>
        public MyJsonSerializer(Newtonsoft.Json.JsonSerializer serializer)
        {
            ContentType = "application/json";
            _serializer = serializer;
        }

        /// <summary>
        /// Serialize the object as JSON
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <returns>JSON as String</returns>
        public string Serialize(object obj)
        {
            if (obj is Mail)
            {

                Mail mail = (Mail)obj;
                string response = "";
                BuiltJson bj = new BuiltJson();
                bj.openClass("message");
                bj.addParametr("text", mail.text);
                bj.addParametr("_subject", mail.subject);
                bj.openArray("to");
                bj.addNextArrayElement();
                bj.addParametr("email", mail.to[0].email);
                bj.closeArray();
                bj.openArray("attachments");
                bj.addNextArrayElement();
                bj.closeArray();
                return bj.getResult();
            }
            else
            {
                //BuiltJson bj = new BuiltJson();
                //bj.addParametr("key", obj.ToString());
                //return bj.getResult();
                return JsonConvert.SerializeObject(obj);
            }

            /*
            "key": "F3oFPMyvxI2JQyEpIydqFw",
            "message": {
                "text": "Example text _content",
                "_subject": "example _subject",
                "to": [
                    {
                    "email": "testmailsender4@gmail.com"
                    }
                ],
                "attachments": [
                    {
                    }
                ]
            }
             */


        }
        class BuiltJson
        {
            string result;
            bool openNewSegment;
            bool firstElementInArray;
            public BuiltJson()
            {
                result += "";
                openNewSegment = false;
                firstElementInArray = true;
            }
            public void addParametr(string s,string value)
            {
                checkNewSegment();
                this.add(s);
                result += ':';
                this.add(value);
            }
            public void openClass(string s)
            {
                openNewStructure(s);
                result += ':';
                result += '{';

            }
            public void openArray(string s)
            {
                openNewStructure(s);
                result += ':';
                result += '[';
            }
            public void addNextArrayElement()
            {
                if (!firstElementInArray)
                    result += '}';
                if (openNewSegment == true)
                    result += ',';
                else
                    openNewSegment = true;
                openNewSegment = false;
                result += '{';
                firstElementInArray = false;
            }
            public void closeArray()
            {
                result += ']';
            }
            public string getResult() 
            {
                return result;
            }
            private void add(string s)
            {
                result += '"';
                result += s;
                result += '"';
            }
            private void checkNewSegment()
            {
                if (openNewSegment == true)
                    result += ',';
                else
                    openNewSegment = true;
            }
            private void openNewStructure(string s)
            {
                checkNewSegment();
                openNewSegment = false;
                this.add(s);
            }

        }

        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string DateFormat { get; set; }
        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string RootElement { get; set; }
        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string Namespace { get; set; }
        /// <summary>
        /// Content type for serialized _content
        /// </summary>
        public string ContentType { get; set; }
    }
}