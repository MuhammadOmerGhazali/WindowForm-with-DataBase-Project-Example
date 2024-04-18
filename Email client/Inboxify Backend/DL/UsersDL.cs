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

        public static List<Users> GetUserList()
        {
            List<Users> UserList = new List<Users>();
            
            try
            {
                SqlConnection con = new SqlConnection(Connection.connectionString);
                con.Open ();
                string query = "SELECT * From Users";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader ();
                while (rdr.Read ()) 
                {
                    Users user = new Users (rdr.GetString(1),rdr.GetString(2),rdr.GetString(3));
                    UserList.Add (user);
                }
                con.Close ();
            }
            catch(Exception ex)
            {
                return null;
            }
            return UserList;
        }

        public static void Find_User(string email)
        {
            List<Users> UserList = new List<Users>();
            try
            {
                SqlConnection con = new SqlConnection(Connection.connectionString);
                con.Open();
                string query = $"SELECT * From Users WHERE Email = {email}";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Users user = new Users(rdr.GetString(1), rdr.GetString(2), rdr.GetString(3));
                    UserList.Add(user);
                }
                con.Close();
                
            }
            catch (Exception ex) 
            {

            }
        }
        public static Users Check_Credentials(string email,string password)
        {
            foreach (Users user in GetUserList())
            {
                if (email == user.Get_Email() && user.Check_Password(password) == true)
                {
                    return user;
                }
            }
            return null;
        }
        public static List<Users> GetUserByPerms(string perms)
        {
            List <Users> ListToBeReturned = new List <Users> ();

            foreach (Users user in GetUserList()) 
            {
                if (user.Get_User_Perm() == perms)
                {
                    ListToBeReturned.Add (user);
                }
            }

            return ListToBeReturned;
        }
        public static void Add_User(Users user)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    string query = "INSERT INTO Users(Email, password, perms) VALUES (@Email, @password, @perms)";
                    SqlCommand command = new SqlCommand(query, connection);
                    
                    command.Parameters.Add(new SqlParameter("@Email", user.Get_Email()));
                    command.Parameters.Add(new SqlParameter("@password", user.Get_Password()));
                    command.Parameters.Add(new SqlParameter("@perms", user.Get_User_Perm()));
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void Remove_User(Users user)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    string query = "DELETE FROM Users WHERE UserId = (SELECT UserId FROM Student WHERE Email = @Email AND password = @password AND perms = @perms)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.Add(new SqlParameter("@Email", user.Get_Email()));
                    command.Parameters.Add(new SqlParameter("@password", user.Get_Password()));
                    command.Parameters.Add(new SqlParameter("@perms", user.Get_User_Perm()));
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }
        public static void Change_user_password(string email,string newPassword,string oldPassword)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    string query = "UPDATE Users SET Email = @Email, password = @password WHERE UserID = (SELECT UserID FROM Users WHERE Email = @Email)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.Add(new SqlParameter("@Email", email));
                    command.Parameters.Add(new SqlParameter("@password", newPassword));
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }
        //public static void Update_userdata();
        //public static void Save_userdata();
    }
}
