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


namespace Email_client.DL
{
    public class UsersDL
    {
        public static void Add_User(Users user)
        {
            SqlConnection connection = new SqlConnection(Connection.connectionString);
            connection.Open();

            string query = "INSERT INTO Users(Email, password, perms) VALUES (@Email, @password, @perms)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add(new SqlParameter("@Email", user.Get_Email()));
            command.Parameters.Add(new SqlParameter("@password", user.Get_Password()));
            command.Parameters.Add(new SqlParameter("@perms", user.Get_User_Perm()));
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static Users Check_Credentials(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
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
        public static List<Users> GetUserList()
        {
            List<Users> UserList = new List<Users>();

            SqlConnection con = new SqlConnection(Connection.connectionString);
            con.Open();
            string query = "SELECT * From Users";
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

    }
}
