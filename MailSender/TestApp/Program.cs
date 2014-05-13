using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender;
using MandrillMailSender;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string apikey = "52DOhihllN57eVUmfMcCQg";
            MailSenderInterface m = new MandrillMailSenderClass(apikey);
            m.TestKey();
        }
    }
}
