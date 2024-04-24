using Email_client.BL;
using Inboxify_Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Inboxify_Backend.DL
{
    public class EmailDL: IEmailDL
    {
        public void AddEmail(Email email)
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
        public Email GetEmailByID(int emailID)
        {
            Email email = null;
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Emails WHERE Email_ID = @EmailID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmailID", emailID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string sender = reader["Sender"].ToString();
                                string receiver = reader["Receiver"] == DBNull.Value ? null : reader["Receiver"].ToString();
                                string subject = reader["Subject"].ToString();
                                string body = reader["Body"] == DBNull.Value ? null : reader["Body"].ToString();
                                string footer = reader["Footer"] == DBNull.Value ? null : reader["Footer"].ToString();
                                string tag = reader["Tag"] == DBNull.Value ? null : reader["Tag"].ToString();
                                
                                email = new Email(emailID, sender, receiver, subject, body, footer, tag);
                                ObjectHandler.FileEmailDL.AddEmail(email);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions here, e.g., log or throw
                    Console.WriteLine($"Error retrieving email: {ex.Message}");
                }
            }
            return email ?? new Email(0, "0", "0", "0", "0", "0", "0");
        }
        public Email GetEmail(string subject, string sender)
        {
            Email email = null;
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Emails WHERE Sender = @Sender AND Subject = @Subject";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Sender", sender);
                        command.Parameters.AddWithValue("@Subject", subject);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int emailID = reader.GetInt32(reader.GetOrdinal("Email_ID"));
                                string receiver = reader.GetString(reader.GetOrdinal("Receiver"));
                                string body = reader.GetString(reader.GetOrdinal("Body"));
                                string footer = reader.GetString(reader.GetOrdinal("Footer"));
                                string tag = reader.GetString(reader.GetOrdinal("Tag"));

                                email = new Email(emailID, sender, receiver, subject, body, footer, tag);
                            }
                        }
                    }
                    connection.Close();
                    return email;
                }
                catch (Exception ex)
                {
                    // Handle exceptions here, e.g., log or throw
                    Console.WriteLine($"Error retrieving email: {ex.Message}");
                }
            }
            return email ?? new Email(0, "0", "0", "0", "0", "0", "0");
        }
        public Email GetEmail(string sender, string receiver, string subject)
        {
            Email email = null;
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Emails WHERE Sender = @Sender AND Receiver = @Receiver AND Subject = @Subject";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Sender", sender);
                        command.Parameters.AddWithValue("@Receiver", receiver);
                        command.Parameters.AddWithValue("@Subject", subject);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int emailID = reader.GetInt32(reader.GetOrdinal("Email_ID"));
                                string body = reader["Body"].ToString();
                                string footer = reader["Footer"].ToString();
                                string tag = reader["Tag"].ToString();

                                email = new Email(emailID, sender, receiver, subject, body, footer, tag);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions here, e.g., log or throw
                    Console.WriteLine($"Error retrieving email: {ex.Message}");
                }
            }
            return email ?? new Email(0, "0", "0", "0", "0", "0", "0");
        }

        public void UpdateTag(string tag)
        {
            if (Connection.currentEmail != null)
            {
                SqlConnection connection = new SqlConnection(Connection.connectionString);
                connection.Open();
                string query = "UPDATE Emails SET Tag = @Tag WHERE Email_ID = @Email_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("@Tag", tag));
                command.Parameters.Add(new SqlParameter("@Email_ID", Connection.currentEmail.Get_ID()));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
