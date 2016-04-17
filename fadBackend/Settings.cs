using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fad2.Backend
{
    public class Settings
    {
        public string Url { get; set; }
        [Setting("ID")]
        public string WlanSdCardId { get; set; }
        [Setting("DHCP_Enabled", TrueValue ="YES", FalseValue ="NO", Default ="YES")]
        public bool WlanSdDhcpEnabled { get; set; }
        [Setting("IP_Address")]
        public string WlanSdIpAddress { get; set; }
        [Setting("Subnet_Mask")]
        public string WlanSdSubnetMask { get; set; }
        [Setting("Default_Gateway")]
        public string WlanSdDefaultGateway { get; set; }
        [Setting("Preferred_DNS_Server")]
        public string WlanSdPreferredDns { get; set; }
        [Setting("Alternate_DNS_Server")]
        public string WlanSdAlternateDns { get; set; }
        [Setting("Proxy_Server_Enabled", TrueValue ="YES", FalseValue ="NO", Default ="NO")]
        public bool WlanSdProxyEnabled { get; set; }
        [Setting("Proxy_Server_Name")]
        public string WlanSdProxyAddress { get; set; }
        [Setting("Port_Number", Default ="8080")]
        public int WlanSdProxyPort { get; set; }
        [Setting("APPAUTOTIME", Default = "300000")]
        public int AppAutoTime { get; set; }
        [Setting("APPINFO")]
        public string AppInfo { get; set; }
        [Setting("APPMODE")]
        public int AppMode { get; set; }
        [Setting("APPNAME")]
        public string AppName { get; set; }
        [Setting("APPNETWORKKEY")]
        public string AppNetworkKey { get; set; }
        [Setting("APPSSID")]
        public string AppSsid { get; set; }
        [Setting("BRGNETWORKKEY")]
        public string BrgNetworkKey { get; set; }
        [Setting("BRGSSID")]
        public string BrgSsid { get; set; }
        [Setting("CID")]
        public string Cid { get; set; }
        [Setting("CIPATH")]
        public string CiPath { get; set; }
        [Setting("DELCGI")]
        public string DisableCgi { get; set; }
        [Setting("DNSMODE", TrueValue ="1", FalseValue ="0", Default ="1")]
        public bool DnsAlways { get; set; }
        [Setting("IFMODE", TrueValue ="1", FalseValue ="0", Default ="0")]
        public bool InterfaceEnabled { get; set; }
        [Setting("LOCK", TrueValue ="1", FalseValue ="0")]
        public bool Locked { get; set; }
        [Setting("LUA_RUN_SCRIPT")]
        public string LuaRunScript { get; set; }
        [Setting("LUA_SD_EVENT")]
        public string LuaSdEvent { get; set; }
        [Setting("MASTERCODE")]
        public string Mastercode { get; set; }
        [Setting("NOISE_CANCEL", TrueValue ="2", FalseValue ="0", Default ="0")]
        public bool NoiseCancel { get; set; }
        [Setting("PRODUCT")]
        public string ProductCode { get; set; }
        [Setting("STA_RETRY_CT")]
        public int StaRetries { get; set; }
        [Setting("TIMEZONE")]
        public int TimeZone { get; set; }
        [Setting("UPDIR")]
        public string UploadDir { get; set; }
        [Setting("UPLOAD", TrueValue ="1", FalseValue ="0", Default ="0")]
        public bool UploadEnabled { get; set; }
        [Setting("VENDOR")]
        public string Vendor { get; set; }
        [Setting("VERSION")]
        public string FirmwareVersion { get; set; }
        [Setting("WEBDAVr")]
        public int WebDavMode { get; set; }

        public Settings()
        {
            Url = "http://flashair";
        }
    }
}
