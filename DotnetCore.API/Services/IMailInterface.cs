using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.API.Services
{
    interface IMailInterface
    {
        void Send(string subject, string message);
    }
}
