namespace fad2.Backend
{
    /// <summary>
    /// Card Settings
    /// </summary>
    public class Settings
    {
        [Setting("ID", Parent = "WLANSD")]
        public string WlanSdCardId { get; set; }

        [Setting("DHCP_Enabled", Parent = "WLANSD", TrueValue = "YES", FalseValue = "NO", Default = "YES")]
        public bool WlanSdDhcpEnabled { get; set; } = true;

        [Setting("IP_Address", Parent = "WLANSD")]
        public string WlanSdIpAddress { get; set; }

        [Setting("Subnet_Mask", Parent = "WLANSD")]
        public string WlanSdSubnetMask { get; set; }

        [Setting("Default_Gateway", Parent = "WLANSD")]
        public string WlanSdDefaultGateway { get; set; }

        [Setting("Preferred_DNS_Server", Parent = "WLANSD")]
        public string WlanSdPreferredDns { get; set; }

        [Setting("Alternate_DNS_Server", Parent = "WLANSD")]
        public string WlanSdAlternateDns { get; set; }

        [Setting("Proxy_Server_Enabled", Parent = "WLANSD", TrueValue = "YES", FalseValue = "NO", Default = "NO")]
        public bool WlanSdProxyEnabled { get; set; } = false;

        [Setting("Proxy_Server_Name", Parent = "WLANSD")]
        public string WlanSdProxyAddress { get; set; }

        [Setting("Port_Number", Parent = "WLANSD", Default = "8080")]
        public int WlanSdProxyPort { get; set; } = 8080;

        [Setting("APPAUTOTIME", Parent = "WLANSD", Default = "300000")]
        public int AppAutoTime { get; set; } = 300000;

        [Setting("APPINFO", Parent = "Vendor")]
        public string AppInfo { get; set; }

        [Setting("APPMODE", Parent = "Vendor", Default = "0")]
        public int AppMode { get; set; }

        [Setting("APPNAME", Parent = "Vendor")]
        public string AppName { get; set; }

        [Setting("APPNETWORKKEY", Parent = "Vendor")]
        public string AppNetworkKey { get; set; }

        [Setting("APPSSID", Parent = "Vendor")]
        public string AppSsid { get; set; }

        [Setting("BRGNETWORKKEY", Parent = "Vendor")]
        public string BrgNetworkKey { get; set; }

        [Setting("BRGSSID", Parent = "Vendor")]
        public string BrgSsid { get; set; }

        [Setting("CID", Parent = "Vendor")]
        public string Cid { get; set; }

        [Setting("CIPATH", Parent = "Vendor")]
        public string CiPath { get; set; }

        [Setting("DELCGI", Parent = "Vendor")]
        public string DisableCgi { get; set; }

        [Setting("DNSMODE", Parent = "Vendor", TrueValue = "1", FalseValue = "0", Default = "1")]
        public bool DnsAlways { get; set; } = true;

        [Setting("IFMODE", Parent = "Vendor", TrueValue = "1", FalseValue = "0", Default = "0")]
        public bool InterfaceEnabled { get; set; } = false;

        [Setting("LOCK", Parent = "Vendor", TrueValue = "1", FalseValue = "0")]
        public bool Locked { get; set; }

        [Setting("LUA_RUN_SCRIPT", Parent = "Vendor")]
        public string LuaRunScript { get; set; }

        [Setting("LUA_SD_EVENT", Parent = "Vendor")]
        public string LuaSdEvent { get; set; }

        [Setting("MASTERCODE", Parent = "Vendor")]
        public string Mastercode { get; set; }

        [Setting("NOISE_CANCEL", Parent = "Vendor", TrueValue = "2", FalseValue = "0", Default = "0")]
        public bool NoiseCancel { get; set; } = false;

        [Setting("PRODUCT", Parent = "Vendor")]
        public string ProductCode { get; set; }

        [Setting("STA_RETRY_CT", Parent = "Vendor", Default = "0")]
        public int StaRetries { get; set; }

        [Setting("TIMEZONE", Parent = "Vendor", Default = "0")]
        public int TimeZone { get; set; }

        [Setting("UPDIR", Parent = "Vendor")]
        public string UploadDir { get; set; }

        [Setting("UPLOAD", Parent = "Vendor", TrueValue = "1", FalseValue = "0", Default = "0")]
        public bool UploadEnabled { get; set; } = false;

        [Setting("VENDOR", Parent = "Vendor")]
        public string Vendor { get; set; }

        [Setting("VERSION", Parent = "Vendor")]
        public string FirmwareVersion { get; set; }

        [Setting("WEBDAV", Parent = "Vendor", Default = "0")]
        public int WebDavMode { get; set; }


        /// <summary>
        /// Version from current Card
        /// </summary>
        public string Version
        {
            get
            {
                if (string.IsNullOrEmpty(FirmwareVersion) || FirmwareVersion.Length < 7)
                {
                    return "1.00.00";
                }
                return FirmwareVersion.Substring(FirmwareVersion.Length - 7);
            }
        }
    }
}