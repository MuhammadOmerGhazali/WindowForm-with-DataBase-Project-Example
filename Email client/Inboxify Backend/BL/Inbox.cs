using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_client.BL
{
    internal class Inbox
    {
        List<Email> inbox = new List<Email>();
        private readonly Users user;

        public Inbox(Users user)
        {
            this.user = user;
        }
        public string ReturnEmailstring(int Email_ID)
        {
            foreach (Email email in inbox) 
            {
                if (Email_ID == email.Get_ID())
                {
                    return email.ToString();
                }
            }
            return null;
        }
        public void Add(Email email) 
        {
            inbox.Add(email);
            UpdateID();
        }
        public void Remove(Email email) 
        {
            inbox.Remove(email);
            UpdateID();
        }
        public void UpdateID()
        {
            int x = 0;
            foreach (Email email in inbox) 
            {
                email.Set_ID(x);
                x = x+1;
            }
        }
        public List<Email> SearchByEmail(string email)
        {
            List<Email> list = new List<Email> ();
            foreach (Email emails in inbox)
            {
                if (emails.Get_Sender() == email)
                {
                    list.Add(emails);
                }
            }
            return list;
        }
        
    }
}
