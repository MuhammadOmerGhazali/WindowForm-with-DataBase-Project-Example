using Email_client.BL;
using Inboxify_Backend.BL.Emails;
using Inboxify_Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Inboxify_Backend.DL.User
{
    public class EmailAccountDL : IEmailAccount
    {
        public List<Account> GetAllAccounts(Users user)
        {
            List<Account> accounts = new List<Account>();

            SqlConnection con = new SqlConnection(Connection.connectionString);
            con.Open();
            string query = "SELECT * FROM Accounts WHERE User_Id = @UserId";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Account Account = new Account(rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3));
                accounts.Add(Account);
            }
            con.Close();

            return accounts;
        }
        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();

            SqlConnection con = new SqlConnection(Connection.connectionString);
            con.Open();
            string query = "SELECT * From Accounts";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Account Account = new Account(rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3));
                accounts.Add(Account);
            }
            con.Close();

            return accounts;
        }
        public void Add_Account(Account account)
        {
            SqlConnection con = new SqlConnection(Connection.connectionString);
            con.Open();
            string query = "INSERT INTO Accounts (User_Id, Email, AccountType) VALUES (@UserId, @Email, @AccountType)";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@UserId", account.UserId);
            command.Parameters.AddWithValue("@Email", account.EmailAccount);
            command.Parameters.AddWithValue("@AccountType", account.EmailType);
            command.ExecuteNonQuery();
            con.Close();
        }
        public List<Account> GetAllBussinessAccounts()
        {
            List<Account> accounts = new List<Account>();

            SqlConnection con = new SqlConnection(Connection.connectionString);
            con.Open();
            string query = "SELECT * From Accounts WHERE AccountType = 'Bussiness'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Account Account = new Account(rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3));
                accounts.Add(Account);
            }
            con.Close();

            return accounts;
        }
        public List<Account> GetAllPersonalAccounts()
        {
            List<Account> accounts = new List<Account>();

            SqlConnection con = new SqlConnection(Connection.connectionString);
            con.Open();
            string query = "SELECT * From Accounts WHERE AccountType = 'Personal'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Account Account = new Account(rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3));
                accounts.Add(Account);
            }
            con.Close();

            return accounts;
        }
        public Account GetAccount(string Email_Account)
        {
            SqlConnection con = new SqlConnection(Connection.connectionString);
            con.Open();
            string query = "SELECT * FROM Accounts WHERE Email = @Email";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@Email", Email_Account);
            SqlDataReader reader = command.ExecuteReader();
            Account account = new Account();
            if (reader.Read())
            {
                // Populate the account object with data from the database
                account.UserId = reader.GetInt32(reader.GetOrdinal("User_Id"));
                account.EmailAccountId = reader.GetInt32(reader.GetOrdinal("Email_Account_Id"));
                account.EmailAccount = reader.GetString(reader.GetOrdinal("Email"));
                account.EmailType = reader.GetString(reader.GetOrdinal("AccountType"));
            }
            con.Close();
            return account;

        }

    }
}
