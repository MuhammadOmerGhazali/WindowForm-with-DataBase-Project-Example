using Email_client.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inboxify_Backend.Interfaces
{
    internal interface IEmailDL
    {
        void AddEmail(Email email);
        Email GetEmail(string subject, string sender);

    }
}
