using Email_client.DL;
using Inboxify_Backend.DL;
using Inboxify_Backend.DL.FH;
using Inboxify_Backend.DL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inboxify_Backend.Interfaces
{
    public static class ObjectHandler
    {
        public static AdminDL AdminDL = new AdminDL();
        public static EndUserDL EndUserDL = new EndUserDL();
        public static EmailAccountDL EmailAccountDL = new EmailAccountDL();
        public static EmailDL EmailDL = new EmailDL();
        public static FileEmailDL FileEmailDL = new FileEmailDL();

    }
}
