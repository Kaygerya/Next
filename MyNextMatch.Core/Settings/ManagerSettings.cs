using System;
using System.Collections.Generic;
using System.Text;

namespace MyNextMatch.Core.Settings
{
    public class ManagerSettings
    {
        public static string ContexConnectionString { get; set; }
        public static string ContextDbType { get; set; }

        public string UserUrl { get; set; }
        public string AddressUrl { get; set; }
        public string UserAddressUrl { get; set; }
    }
}
