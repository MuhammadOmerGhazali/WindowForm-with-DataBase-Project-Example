using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inboxify_Backend.BL.Emails
{
    public class Account
    {
        public Account() { }
        public Account(int userId, int email_account_Id, string email_Account, string email_Password)
        {
            this.userId = userId;
            Email_account_Id = email_account_Id;
            Email_Account = email_Account;
            Email_Password = email_Password;
        }

        protected int userId;
        protected int Email_account_Id;
        protected string Email_Account;
        protected string Email_Password;
        protected string Email_type;
    }
}
