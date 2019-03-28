using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo.Net
{
    /// <summary>
    /// <https://blog.csdn.net/weixin_38208401/article/details/79037475>
    /// </summary>
    public static class SoftwaresInfo
    {
        /// <summary>
        /// 从注册表获取本机安装的软件信息
        /// </summary>
        /// <returns>返回软件名、版本号的</returns>
        public static Dictionary<string, string> GetSoftWares()
        {
            List<RegistryKey> RegistryKeys = new List<RegistryKey>();
            //对应注册表
            RegistryKeys.Add(Registry.ClassesRoot);
            RegistryKeys.Add(Registry.CurrentConfig);
            RegistryKeys.Add(Registry.CurrentUser);
            RegistryKeys.Add(Registry.LocalMachine);
            RegistryKeys.Add(Registry.PerformanceData);
            RegistryKeys.Add(Registry.Users);

            Dictionary<string, string> Softwares = new Dictionary<string, string>();
            string SubKeyName = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";
            foreach (RegistryKey Registrykey in RegistryKeys)
            {
                using (RegistryKey RegistryKey1 = Registrykey.OpenSubKey(SubKeyName, false))
                {
                    if (RegistryKey1 == null)
                        continue;
                    if (RegistryKey1.GetSubKeyNames() == null)
                        continue;
                    string[] KeyNames = RegistryKey1.GetSubKeyNames();
                    foreach (string KeyName in KeyNames)
                    {
                        using (RegistryKey RegistryKey2 = RegistryKey1.OpenSubKey(KeyName, false))
                        {
                            if (RegistryKey2 == null)
                                continue;
                            //获取软件名
                            string SoftwareName = RegistryKey2.GetValue("DisplayName", "").ToString();
                            //获取软件版本
                            string SoftwareVersion = RegistryKey2.GetValue("DisplayVersion", "").ToString();

                            if (!string.IsNullOrEmpty(SoftwareName))
                            {
                                if (!Softwares.ContainsKey(SoftwareName))
                                {
                                    Softwares.Add(SoftwareName, SoftwareVersion);
                                }
                            }
                        }
                    }
                }
            }
            return Softwares;
        }
    }
}
