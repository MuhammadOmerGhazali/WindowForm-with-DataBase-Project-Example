using Email_client.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inboxify_Backend.Interfaces
{
    internal interface IUserDL
    {
        void Add_User(Users user);
        Users Check_Credentials(string email, string password);
    }
}
