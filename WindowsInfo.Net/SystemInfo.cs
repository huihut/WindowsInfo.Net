using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo.Net
{
    public class SystemInfo
    {
        /// <summary>
        /// 获取计算机名
        /// </summary>
        public string GetComputerName()
        {
            return Environment.MachineName;
        }

        /// <summary>
        /// 操作系统的登录用户名
        /// </summary>
        public string GetUserName()
        {
            return Environment.UserName;
        }
        
        /// <summary>
        /// 操作系统类型
        /// </summary>
        public string GetSystemType()
        {
            string st = "";
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                st = mo["SystemType"].ToString();
            }
            return st;
        }
    }
}
