using System;
using Email_client.BL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Inboxify_Backend.Interfaces;


namespace Email_client.DL
{
    public class AdminDL : IUserDL
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
                            return Connection.currentUser = new Users(rdr.GetString(1), rdr.GetString(2), rdr.GetString(3)  );
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
            string query = "SELECT * From Users Where perms = 'Admin'";
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
        public List<string> GetAdminAccountList()
        {
            List<string> UserList = new List<string>();

            SqlConnection con = new SqlConnection(Connection.connectionString);
            con.Open();
            string query = "SELECT username From Users Where perms = 'Admin'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                UserList.Add(rdr.GetString(0));
            }
            con.Close();

            return UserList;
        }
        public void ChangetoAdmin(string username)
        {
            SqlConnection connection = new SqlConnection(BL.Connection.connectionString);
            connection.Open();
            string query = "UPDATE Users SET perms = @perms WHERE UserID = (SELECT UserID FROM Users WHERE username = @username)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@perms", "Admin"));
            command.Parameters.Add(new SqlParameter("@username", username));
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void ChangetoEndUser(string username)
        {
            SqlConnection connection = new SqlConnection(BL.Connection.connectionString);
            connection.Open();
            string query = "UPDATE Users SET perms = @perms WHERE UserID = (SELECT UserID FROM Users WHERE username = @username)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@perms", "EndUser"));
            command.Parameters.Add(new SqlParameter("@username", username));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
