using Inboxify_Backend.BL.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_client.BL
{
    public static class Connection
    {
        public static Users currentUser = new Users();
        public static Account currentAccount = new Account();
        public static Email currentEmail = new Email();
        public static string connectionString = "Data Source=DESKTOP-VCJSKBS\\SQLEXPRESS;Initial Catalog=\"Inboxify\";Integrated Security=True;";
    }
    
}
