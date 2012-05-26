using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace YourDay.Constants
{
    public class Config
    {
        public static string GetLink(string key, params string[] values)
        {
            return System.String.Format(ConfigurationManager.AppSettings[key], values);
        }
    }
}
