﻿using Email_client.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inboxify_Backend.BL
{
    public class Admin : Users
    {
        public Admin() { }
        public Admin(string user_name, string user_password):base (user_name,user_password)
        {
            this.user_perm = "Admin";
        }
    }
}
