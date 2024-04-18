using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_client.BL
{
    public static class Connection
    {
        public static Users currentUser = null;
        public static string connectionString = "Data Source=DESKTOP-VCJSKBS\\SQLEXPRESS;Initial Catalog=\"Email client\";Integrated Security=True;Trust Server Certificate=True";
    }
    
}
