using Email_client.BL;
using Inboxify_Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inboxify_Backend.DL
{
    public class EndUserDL : IUserDL
    {
        public void Add_User(Users user)
        {
            SqlConnection connection = new SqlConnection(Connection.connectionString);
            connection.Open();

            string query = "INSERT INTO Users(username, password, perms) VALUES (@username, @password, @perms)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add(new SqlParameter("@username", user.Get_Email()));
            command.Parameters.Add(new SqlParameter("@password", user.Get_Password()));
            command.Parameters.Add(new SqlParameter("@perms", user.Get_User_Perm()));
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Users Check_Credentials(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Users WHERE username = @username AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            return Connection.currentUser = new Users(rdr.GetString(1), rdr.GetString(2), rdr.GetString(3));
                        }
                    }
                }
            }
            return null;
        }
        public List<Users> GetUserList()
        {
            List<Users> UserList = new List<Users>();

            SqlConnection con = new SqlConnection(Connection.connectionString);
            con.Open();
            string query = "SELECT * From Users Where perms = 'EndUser'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Users user = new Users(rdr.GetString(1), rdr.GetString(2), rdr.GetString(3));
                UserList.Add(user);
            }
            con.Close();

            return UserList;
        }
        public Users FillInfo(string email, string password)
        {
            SqlConnection connection = new SqlConnection(Connection.connectionString);
            connection.Open();
            string query = "SELECT * FROM Users WHERE username = @username AND password = @password";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@username", email);
            command.Parameters.AddWithValue("@password", password);

            using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                // Populate the user object with data from the database
                                int id = reader.GetInt32(reader.GetOrdinal("UserID"));
                                string email1 = reader.GetString(reader.GetOrdinal("username"));
                                string password1 = reader.GetString(reader.GetOrdinal("password"));
                                string perms = reader.GetString(reader.GetOrdinal("perms"));
                    Users user = new Users(id,email1,password1,perms);
                    return user;
                }
                            else
                            {
                                // If no matching user is found, return null
                                return null;
                            }
                        }

                

            
        }
    }
}
