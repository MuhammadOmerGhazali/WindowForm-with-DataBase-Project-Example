﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inboxify_Backend.BL.Emails
{
    public class Bussiness_Email : Account
    {
        public Bussiness_Email() { }
        public Bussiness_Email(int userId, int email_account_Id, string email_Account, string email_Password):base(userId,email_account_Id,email_Account,email_Password)
        {
            Email_type = "Bussiness";
        }

    }
}
