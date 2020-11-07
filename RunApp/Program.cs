using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Security;
using System.Diagnostics;

namespace RunApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SecureString userpass = new SecureString();
                
            Console.WriteLine("Run this program with 3 params");
            Console.WriteLine("   1 - The Name of a local adminstrator (adminstrator)");
            Console.WriteLine("   2 - The Password of the local adminstrator");
            Console.WriteLine("   3 - The Full Path and name of a program which do you want to run");
            Console.WriteLine();

            try
            {
                string username = args[0];
                string ps = args[1];

                char[] charArr = ps.ToCharArray();

                foreach (var item in charArr)
                    userpass.AppendChar(item);

                var psi = new ProcessStartInfo
                {
                    FileName = args[2],
                    UserName = username,
                    Domain = "",
                    Password = userpass,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                Process.Start(psi);

                Console.WriteLine();
                Console.WriteLine($"Run application - {args[2]}");

            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error message - {ex.Message}");
                Console.ReadLine();
            }
            
        }
    }
}
