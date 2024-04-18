using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_client.BL
{
    public class Users
    {
        private readonly string user_perm;
        private readonly string user_email;
        private string user_password;
        
        public Users(string user_perm ,string user_email, string user_password)
        {
            this.user_perm = user_perm;
            this.user_email = user_email;
            this.user_password = user_password;
        }
        public Users(string user_email, string user_password)
        {
            this.user_perm = "";
            this.user_email = user_email;
            this.user_password = user_password;
        }
            public string Get_Email()
        {
            return user_email;
        }
        public string Get_Password()
        {
            return user_password;
        }
        public string Get_User_Perm()
        {
            return user_perm;
        }
        public bool Check_Password(string password) 
        {
            if (user_password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        public void Change_Password(string new_password)
        {
            user_password = new_password;
        }

    }
}
