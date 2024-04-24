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
        public Account(int userId, int email_account_Id, string email_Account)
        {
            this.userId = userId;
            Email_account_Id = email_account_Id;
            Email_Account = email_Account;
        }
        public Account(int userId, string email_Account,string Email_type)
        {
            this.userId = userId;
            Email_Account = email_Account;
            this.Email_type = Email_type;
        }

        protected int userId;
        protected int Email_account_Id;
        protected string Email_Account;
        protected string Email_type;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public int EmailAccountId
        {
            get { return Email_account_Id; }
            set { Email_account_Id = value; }
        }

        public string EmailAccount
        {
            get { return Email_Account; }
            set { Email_Account = value; }
        }

        public string EmailType
        {
            get { return Email_type; }
            set { Email_type = value; }
        }
    }
}
