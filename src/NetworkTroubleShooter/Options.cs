using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkTroubleshooter
{
    public class Options
    {
        public int PingTimeout = 1000;
        public int HTTPTimeout = 4000;
        public string[] InternetServers = new string[] { "http://google.com", "http://netflix.com", "http://microsoft.com" };
    }
}
