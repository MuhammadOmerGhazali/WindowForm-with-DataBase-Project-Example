using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_client.BL
{
    public class Email
    {
        private int email_ID;
        private readonly string sender_email;
        private readonly string receiver_email;
        private readonly string email_subject;
        private readonly string email_body;
        private readonly string email_footer;
        private readonly string attachment = null;
        private  string tag;

        public Email(string sender_email,string receiver_email,string email_subject,string email_body,string email_footer,string tag) 
        {
            this.sender_email = sender_email;
            this.receiver_email = receiver_email;
            this.email_subject = email_subject;
            this.email_body = email_body;
            this.email_footer = email_footer;
            this.tag = tag;
        }
        public Email(int email_ID,string sender_email, string receiver_email, string email_subject, string email_body, string email_footer, string tag)
        {
            this.email_ID = email_ID;
            this.sender_email = sender_email;
            this.receiver_email = receiver_email;
            this.email_subject = email_subject;
            this.email_body = email_body;
            this.email_footer = email_footer;
            this.tag = tag;
        }
        public Email()
        {

        }
        public int Get_ID()
        {
            return this.email_ID;
        }
        public void Set_ID(int id)
        {
            this.email_ID= id;
        }
        public string Get_Tag()
        {
            return tag;
        }
        public void Set_Tag(string tag)
        {
            this.tag = tag;
        }
        public string Get_Sender()
        {
            return sender_email;
        }
        public string Get_receiver()
        {
            return receiver_email;
        }
        public string Get_Email_Subject() 
        {
            return email_subject;
        }
        public string Get_Email_Body()
        {
            return email_body;
        }
        public string Get_Email_Footer() 
        {
            return email_footer;
        }
        public string To_string()
        {
            return "From: "+sender_email+"\n"+"To: "+receiver_email+"\n"+"Subject: "+email_subject+"\n\n"+email_body+"\n\n"+email_footer;
        }
    }
}
