using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace NetworkTroubleshooter
{
    delegate void StringColorArgReturningVoidDelegate(string text, Color color);

    public partial class Main : Form
    {
        Ping pinger = new Ping();
        NetworkInterface[] interfaces;
        SourceLevels LoggingLevel = SourceLevels.Information;
        Options options = new Options();

        public Main()
        {
            InitializeComponent();

            optionsPanel.Hide();
            
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                interfaces = NetworkInterface.GetAllNetworkInterfaces();

                //troubleshoot active nics
                foreach(NetworkInterface ni in interfaces)
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem();
                    tsmi.Text = ni.Name + ": " + ni.Description;
                    tsmi.Click += Tsmi_Click;
                    troubleshootInterfaceToolStripMenuItem.DropDownItems.Add(tsmi);

                    if (!ni.Name.ToLowerInvariant().Contains("virtual") && 
                        !ni.Description.ToLowerInvariant().Contains("virtual") &&
                        ni.OperationalStatus == OperationalStatus.Up &&
                        ni.NetworkInterfaceType != NetworkInterfaceType.Tunnel &&
                        ni.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                        ni.NetworkInterfaceType != NetworkInterfaceType.Unknown)
                    {
                        Troubleshoot(ni);
                    }
                }
            }
            else
            {
                outputTextBox.AppendText("No networks available\n", Color.DarkRed);
            }
        }

        private void Tsmi_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
                if (tsmi != null)
                {
                    foreach (NetworkInterface ni in interfaces)
                    {
                        if (tsmi.Text == ni.Name + ": " + ni.Description)
                        {
                            Troubleshoot(ni);
                        }
                    }
                }
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleTest test = new SingleTest();
            if (test.ShowDialog() == DialogResult.OK)
            {
                Log("\n== Single Test ==\n", Color.DarkMagenta);
                if (test.TestName == "DNS")
                {
                    TestDNS(test.Param);
                }
                else if (test.TestName == "HTTP")
                {
                    TestHttp(test.Param);
                }
                else if (test.TestName == "Proxy")
                {
                    TestProxy(test.Param);
                }
                else if (test.TestName == "PAC")
                {
                    ProcessPAC(test.Param);
                }
                else if (test.TestName == "Ping")
                {
                    TestPing(IPAddress.Parse(test.Param), "");
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoggingLevel = SourceLevels.Information;
            Log(string.Format("Logging level set to: {0}\n", LoggingLevel), Color.DarkViolet);
        }

        private void verboseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoggingLevel = SourceLevels.Verbose;
            Log(string.Format("Logging level set to: {0}\n", LoggingLevel), Color.DarkViolet);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pingTimeoutUpDown.Value = options.PingTimeout;
            httpTimeoutUpDown.Value = options.HTTPTimeout;

            serverTextBox.Clear();
            foreach (string server in options.InternetServers)
            {
                serverTextBox.AppendText(server + "\n");
            }

            optionsPanel.Show();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            options.PingTimeout = (int)pingTimeoutUpDown.Value;
            options.HTTPTimeout = (int)httpTimeoutUpDown.Value;

            if (serverTextBox.Text.Length > 0)
            {
                List<string> servers = new List<string>();
                string[] splitServers = serverTextBox.Text.Split('\n');

                for (int i = 0; i < splitServers.Length; i++)
                {
                    if (splitServers[i].Length > 5)
                        servers.Add(splitServers[i].Trim());
                }

                options.InternetServers = servers.ToArray();
            }

            optionsPanel.Hide();
        }

        private void Log(string result, Color color = default(Color))
        {
            if (outputTextBox.InvokeRequired)
            {
                outputTextBox.Invoke(new StringColorArgReturningVoidDelegate(Log), new object[] { result, color });
                return;
            }

            outputTextBox.AppendText(result, color);
        }

        private void Troubleshoot(NetworkInterface ni)
        {
            outputTextBox.Clear();

            new Thread(delegate ()
            {
                try
                {
                    Log(string.Format("== {0}: {1} ==\n", ni.Name, ni.Description), Color.DarkGreen);
                    Log(string.Format("Status: {0}\n", ni.OperationalStatus));
                    Log(string.Format("Type: {0}\n", ni.NetworkInterfaceType));
                    Log(string.Format("Speed: {0}\n", ni.Speed));
                    Log(string.Format("Supports Multicast: {0}\n", ni.SupportsMulticast));

                    IPInterfaceProperties ipip = ni.GetIPProperties();

                    foreach (UnicastIPAddressInformation uipai in ipip.UnicastAddresses)
                    {
                        Log(string.Format("Unicast {0}: {1} (DHCP Lease: {2}, Duplicate State: {3})\n", uipai.Address.AddressFamily, uipai.Address, uipai.DhcpLeaseLifetime, uipai.DuplicateAddressDetectionState));
                    }

                    if (LoggingLevel == SourceLevels.Verbose)
                    {
                        foreach (MulticastIPAddressInformation mipai in ipip.MulticastAddresses)
                        {
                            Log(string.Format("Multicast {0}: {1}\n", mipai.Address.AddressFamily, mipai.Address));
                        }
                    }

                    foreach (GatewayIPAddressInformation gipai in ipip.GatewayAddresses)
                    {
                        Log(string.Format("Gateway: {0}\n", gipai.Address));
                    }

                    foreach (IPAddress ipa in ipip.DhcpServerAddresses)
                    {
                        Log(string.Format("DHCP: {0}\n", ipa));
                    }

                    foreach (IPAddress ipa in ipip.DnsAddresses)
                    {
                        Log(string.Format("DNS: {0}\n", ipa));
                    }



                    Log("\n== Network Tests ==\n", Color.DarkOrange);

                    foreach (GatewayIPAddressInformation gipai in ipip.GatewayAddresses)
                    {
                        TestPing(gipai.Address, "Gateway");
                    }

                    foreach (IPAddress ipa in ipip.DhcpServerAddresses)
                    {
                        TestPing(ipa, "DHCP");
                    }

                    foreach (IPAddress ipa in ipip.DnsAddresses)
                    {
                        TestPing(ipa, "DNS");
                    }



                    string fromDomain = "Computer";
                    Domain domain = null;
                    try
                    {
                        domain = Domain.GetComputerDomain();
                    }
                    catch(Exception) { } // not on a domain

                    if (domain == null)
                    {
                        try
                        {
                            domain = Domain.GetCurrentDomain(); // computer domain is likely to be better but if not get the user domain
                            fromDomain = "User";
                        }
                        catch (Exception) { } // not on a domain
                    }

                    if (domain != null)
                    {
                        Log("\n== Domain Info ==\n", Color.DarkOrange);
                        Log(string.Format("From: {0}\n", fromDomain));
                        Log(string.Format("Name: {0}\n", domain.Name));
                        Log(string.Format("Mode: {0}\n", domain.DomainMode));

                        Log("= Controller Tests =\n", Color.DarkOrange);
                        foreach (DomainController dc in domain.DomainControllers)
                        {
                            TestPing(IPAddress.Parse(dc.IPAddress), dc.Name);
                        }
                    }
                    


                    Log("\n== Proxy Tests ==\n", Color.DarkOrange);

                    string proxyResults = NetShQuery("winhttp show proxy");
                    proxyResults = proxyResults.Replace("Current WinHTTP proxy settings:", "").Trim();
                    Log(string.Format("Default User Proxy: {0}\n", proxyResults));

                    RegistryKey InternetSettings = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings");
                    if (InternetSettings.GetValue("ProxyServer") != null)
                    {
                        string proxyServer = InternetSettings.GetValue("ProxyServer").ToString();
                        Log(string.Format("User Proxy: {0}\n", proxyServer));
                        TestProxy(proxyServer);
                    }

                    if (InternetSettings.GetValue("AutoConfigURL") != null)
                    {
                        string autoConfigUrl = InternetSettings.GetValue("AutoConfigURL").ToString();
                        Log(string.Format("PAC Location: {0}\n", autoConfigUrl));
                        ProcessPAC(autoConfigUrl);
                    }



                    //Internet tests are none specific to the adapter - let windows figure it out
                    Log("\n== Internet Tests ==\n", Color.DarkOrange);

                    foreach (string server in options.InternetServers)
                    {
                        TestDNS(server);
                        TestHttp(server);
                    }
                }
                catch (Exception e)
                {
                    Log(e.Message + "\n", Color.DarkRed);
                }
            }).Start();
        }

        private void TestPing(IPAddress address, string name)
        {
            PingReply pr = pinger.Send(address, options.PingTimeout);
            Log(string.Format("Ping {0}: {1}, {2}, {3}ms\n", name, address, pr.Status, pr.RoundtripTime));
        }
        
        private void TestDNS(string uriOrHost)
        {
            try
            {
                string dnsHost = uriOrHost;
                if (Uri.IsWellFormedUriString(dnsHost, UriKind.Absolute))
                {
                    dnsHost = new Uri(uriOrHost).Host;
                }

                Stopwatch timer = new Stopwatch();
                timer.Start();

                IPAddress[] ips = Dns.GetHostAddresses(dnsHost);
                if (LoggingLevel == SourceLevels.Verbose)
                {
                    foreach (IPAddress ipa in ips)
                    {
                        Log(string.Format("DNS {0} = IP: {1}\n", dnsHost, ipa));
                    }
                }

                timer.Stop();

                Log(string.Format("DNS {0}: {1} addresses, {2}ms\n", dnsHost, ips.Length, timer.ElapsedMilliseconds));
            }
            catch(Exception e)
            {
                Log(string.Format("DNS {0} failed: {1}\n", uriOrHost, e.Message), Color.DarkRed);
            }
        }

        private void TestHttp(string uri)
        {
            try
            { 
                Stopwatch timer = new Stopwatch();
                timer.Start();

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Timeout = options.HTTPTimeout;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            
                timer.Stop();

                Log(string.Format("Direct request {0}: {1}, {2}ms\n", uri, response.StatusDescription, timer.ElapsedMilliseconds));
            }
            catch (Exception e)
            {
                Log(string.Format("Direct request {0} failed: {1}\n", uri, e.Message), Color.DarkRed);
            }
        }

        private string NetShQuery(string query)
        {
            string result = "";

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo("netsh", query);
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                Process netsh = Process.Start(psi);
                result = netsh.StandardOutput.ReadToEnd().Trim();
            }
            catch(Exception e)
            {
                Log(string.Format("netsh query {0} failed: {1}\n", query, e.Message), Color.DarkRed);
            }

            return result;
        }

        private void TestProxy(string proxy)
        {
            string uri = options.InternetServers[0];
            try
            {
                string cleanProxy = proxy;
                if (cleanProxy.IndexOf(':') >= 0)
                {
                    cleanProxy = cleanProxy.Substring(0, cleanProxy.IndexOf(':'));
                }
                
                if (Uri.IsWellFormedUriString(cleanProxy, UriKind.Absolute))
                {
                    cleanProxy = new Uri(cleanProxy).Host;
                }

                IPAddress[] ips = Dns.GetHostAddresses(cleanProxy);
                foreach (IPAddress ipa in ips)
                {
                    TestPing(ipa, "proxy");
                }

                Stopwatch timer = new Stopwatch();
                timer.Start();
                
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Timeout = options.HTTPTimeout;
                request.Proxy = new WebProxy(proxy);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                timer.Stop();

                Log(string.Format("Proxy request {0} via {1}: {2}, {3}ms\n", uri, proxy, response.StatusDescription, timer.ElapsedMilliseconds));
            }
            catch (Exception e)
            {
                Log(string.Format("Proxy request {0} via {1} failed: {2}\n", uri, proxy, e.Message), Color.DarkRed);
            }
        }

        private void ProcessPAC(string pacLocation)
        {
            try
            {
                List<string> proxies = new List<string>();

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pacLocation);
                request.Timeout = options.HTTPTimeout;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string pacContents = new StreamReader(response.GetResponseStream()).ReadToEnd();
                
                Regex proxyPattern = new Regex(@"PROXY ([\w\.\-_]+:\d{1,5})");
                MatchCollection proxyMatches = proxyPattern.Matches(pacContents);
                if (LoggingLevel == SourceLevels.Verbose)
                {
                    Log(string.Format("PAC contains {0} proxy usages\n", proxyMatches.Count));
                }
                
                foreach(Match m in proxyMatches)
                {
                    if (!proxies.Contains(m.Groups[1].Value))
                    {
                        proxies.Add(m.Groups[1].Value);
                    }
                }

                Log(string.Format("PAC {0} testing {1} proxies\n", pacLocation, proxies.Count));

                foreach(string proxy in proxies)
                {
                    TestProxy(proxy);
                }
            }
            catch (Exception e)
            {
                Log(string.Format("Process PAC {0} failed: {1}\n", pacLocation, e.Message), Color.DarkRed);
            }
        }
    }
}
