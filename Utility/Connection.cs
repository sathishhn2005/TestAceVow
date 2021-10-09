using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Connection
    {
        public string GetConnectionString()
        {
            string conStr = ConfigurationManager.ConnectionStrings["AceVowAdmin"].ConnectionString.ToString();
            return conStr;
        }
        public string GetConnectionStringSMTesting()
        {
            string conStr = ConfigurationManager.ConnectionStrings["AllDealzSM"].ConnectionString.ToString();
            return conStr;
        }
    }
}
