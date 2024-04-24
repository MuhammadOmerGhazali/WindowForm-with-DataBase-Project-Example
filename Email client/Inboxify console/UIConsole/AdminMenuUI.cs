using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inboxify_console.UIConsole
{
    public class AdminMenuUI
    {
        public static int PrintMenu()
        {
            Console.WriteLine("======================== Admin Authentication =======================");
            Console.WriteLine("======================== 1.     Log In        =======================");
            Console.WriteLine("======================== 2.     Exit          =======================\n\n");
            Console.WriteLine("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
        public static int PrintMainMenu()
        {
            Console.WriteLine("\n====================          Admin Menu         ====================");
            Console.WriteLine("==================== 1. View Users                 ==================");
            Console.WriteLine("==================== 2. Make Admin                 ==================");
            Console.WriteLine("==================== 3. Make User                  ==================");
            Console.WriteLine("==================== 4. View Stats                 ==================");
            Console.WriteLine("==================== 5. Exit                       ==================");

            Console.WriteLine("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
        public static void FailCred()
        {
            Console.WriteLine("Authentication failed. Please try again.");
            Console.ReadKey();
        }

    }
}
