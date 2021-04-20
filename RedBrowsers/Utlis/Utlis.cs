using RedBrowsers.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
namespace RedBrowsers.Utlis
{
    class Utlis
    {
        private static void CreateRows<T>(List<T> list, StreamWriter sw)
        {
            foreach (var item in list)
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                for (int i = 0; i < properties.Length - 1; i++)
                {
                    var prop = properties[i];
                    sw.Write(prop.GetValue(item) + ",");
                }
                var lastProp = properties[properties.Length - 1];
                sw.Write(lastProp.GetValue(item) + sw.NewLine);
            }
        }
        private static void CreateHeader<T>(List<T> list, StreamWriter sw)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            for (int i = 0; i < properties.Length - 1; i++)
            {
                sw.Write(properties[i].Name + ",");
            }
            var lastProp = properties[properties.Length - 1].Name;
            sw.Write(lastProp + sw.NewLine);
        }
        public static void CreateCSV<T>(List<T> list, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                CreateHeader(list, sw);
                CreateRows(list, sw);
            }
        }
        public static string CreateString(List<Account> Accounts) 
        {
            string ret =string.Empty;
            foreach (Account account in Accounts)
            {
                ret += $"---------------------------------------------{Environment.NewLine}UserName    =  {account.UserName}{Environment.NewLine}PassWord    =  {account.Password}{Environment.NewLine}Website     =  {account.URL}{Environment.NewLine}Application =  {account.Application}{Environment.NewLine}---------------------------------------------";
            }
            return ret;
        }
    }
}
