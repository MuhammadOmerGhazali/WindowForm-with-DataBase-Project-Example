using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_client.BL
{
    public class Users
    {
        protected readonly int id;
        protected string user_perm;
        protected readonly string user_name;
        protected string user_password;

        public Users(int id,string user_email, string user_password, string user_perm)
        {
            this.id = id;
            this.user_name = user_email;
            this.user_password = user_password;
            this.user_perm = user_perm;
        }
        public Users(string user_email, string user_password,string user_perm)
        {
            this.user_name = user_email;
            this.user_password = user_password;
            this.user_perm = user_perm;
        }
        public Users(string user_email, string user_password)
        {
            this.user_perm = "";
            this.user_name = user_email;
            this.user_password = user_password;
        }
        public Users()
        {

        }
        public int Get_Id()
        {
            return id;
        }
        public string Get_Email()
        {
            return user_name;
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
