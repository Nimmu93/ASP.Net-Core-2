using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.API.Services
{
    public class CloudMailService:IMailInterface
    {
        private string _mailTo = "admin@nimmu.com";
        private string _mailFrom = "noreply@nimmu.com";

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with CloudMailService.");
            Debug.WriteLine($"Subject:{subject}");
            Debug.WriteLine($"Message:{message}");
        }
    }
}
