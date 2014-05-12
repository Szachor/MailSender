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
            MailSenderInterface m = new MandrillMailSenderClass("jakies api ki");
            m.TestKey();
        }
    }
}
