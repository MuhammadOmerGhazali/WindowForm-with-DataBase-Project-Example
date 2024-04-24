using Email_client.BL;
using Inboxify_Backend.BL.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inboxify_Backend.Interfaces
{
    internal interface IEmailAccount
    {
        void Add_Account(Account account);
        List<Account> GetAllAccounts(Users user);
        List<Account> GetAllBussinessAccounts();
        List<Account> GetAllPersonalAccounts();
        Account GetAccount(string Email_Account);

    }
}
