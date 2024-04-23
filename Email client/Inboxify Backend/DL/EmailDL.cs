using Email_client.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inboxify_Backend.DL
{
    public static class EmailDL
    {
        public static void AddEmail(Email email)
        {
            SqlConnection connection = new SqlConnection(Connection.connectionString);
            connection.Open();
            string query = "INSERT INTO Emails(Sender, Receiver,Subject,Body,Footer,Tag,Attachment,Date) VALUES (@Sender,@Receiver,@Subject,@Body,@Footer,@Tag,@Attachment,@Date)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add(new SqlParameter("@Sender", email.Get_Sender()));
            command.Parameters.Add(new SqlParameter("@Receiver", email.Get_receiver()));
            command.Parameters.Add(new SqlParameter("@Subject", email.Get_Email_Subject()));
            command.Parameters.Add(new SqlParameter("@Body", email.Get_Email_Body()));
            command.Parameters.Add(new SqlParameter("@Footer", email.Get_Email_Footer()));
            command.Parameters.Add(new SqlParameter("@Tag", email.Get_Tag()));
            command.Parameters.Add(new SqlParameter("@Attachment", ""));
            command.Parameters.Add(new SqlParameter("@Date", DateTime.Now));
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static Email GetEmail(string subject,string sender)
        {
            return null;
        }
    }
}
