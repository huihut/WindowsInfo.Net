using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo.Net
{
    public class NetworkInfo
    {
        /// <summary>
        /// 获取IP地址
        /// </summary>
        public string GetIPAddress()
        {
            string st = "";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    //st=mo["IpAddress"].ToString(); 
                    System.Array ar;
                    ar = (System.Array)(mo.Properties["IpAddress"].Value);
                    st = ar.GetValue(0).ToString();
                    break;
                }
            }
            return st;
        }

        /// <summary>
        /// 获取本地ip地址，多个ip
        /// </summary>
        public String[] GetLocalIpAddress()
        {
            string hostName = Dns.GetHostName();                    //获取主机名称
            IPAddress[] addresses = Dns.GetHostAddresses(hostName); //解析主机IP地址
            string[] IP = new string[addresses.Length];             //转换为字符串形式
            for (int i = 0; i < addresses.Length; i++) IP[i] = addresses[i].ToString();
            return IP;
        }
        
        /// <summary>
        /// 获取外网ip地址
        /// </summary>
        //从网站"http://1111.ip138.com/ic.asp"，获取本机外网ip地址信息串
        //"<html>\r\n<head>\r\n<meta http-equiv=\"content-type\" content=\"text/html; charset=gb2312\">\r\n<title> 
        //您的IP地址 </title>\r\n</head>\r\n<body style=\"margin:0px\"><center>您的IP是：[218.104.71.178] 来自：安徽省合肥市 联通</center></body></html>"

        public string[] GetExtenalIpAddress()
        {
            string[] IP = new string[] { "未获取到外网ip", "" };

            string address = "http://1111.ip138.com/ic.asp";
            string str = GetWebStr(address);

            try
            {
                //提取外网ip数据 [218.104.71.178]
                int i1 = str.IndexOf("[") + 1, i2 = str.IndexOf("]");
                IP[0] = str.Substring(i1, i2 - i1);


                //提取网址说明信息 "来自：安徽省合肥市 联通"
                i1 = i2 + 2; i2 = str.IndexOf("<", i1);
                IP[1] = str.Substring(i1, i2 - i1);
            }
            catch (Exception) { }
            return IP;
        }
        
        /// <summary>
        /// 获取网址address的返回的文本串数据
        /// </summary>
        public string GetWebStr(string address)
        {
            string str = "";
            try
            {
                //从网址中获取本机ip数据
                System.Net.WebClient client = new System.Net.WebClient();
                client.Encoding = System.Text.Encoding.Default;
                str = client.DownloadString(address);
                client.Dispose();
            }
            catch (Exception) { }
            return str;
        }
    }
}
