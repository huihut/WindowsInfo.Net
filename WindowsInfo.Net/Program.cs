using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filename = "info.txt";
                FileStream fs = new FileStream(filename, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                Console.WriteLine("正在获取信息，请稍后...");

                // 系统信息
                sw.WriteLine("---------  系统信息  ---------");
                SystemInfo systemInfo = new SystemInfo();
                sw.WriteLine("计算机名：" + systemInfo.GetComputerName());
                sw.WriteLine("登录用户名：" + systemInfo.GetUserName());
                sw.WriteLine("操作系统类型：" + systemInfo.GetSystemType());
                sw.WriteLine("\n\n");

                // 硬件信息
                sw.WriteLine("---------  硬件信息  ---------");
                HardwareInfo hardwareInfo = new HardwareInfo();
                sw.WriteLine("本机的MAC地址：" + hardwareInfo.GetLocalMac());

                sw.WriteLine("主板序列号：" + hardwareInfo.GetBIOSSerialNumber());
                sw.WriteLine("主板制造厂商：" + hardwareInfo.GetBoardManufacturer());
                sw.WriteLine("主板编号：" + hardwareInfo.GetBoardID());
                sw.WriteLine("主板编号：" + hardwareInfo.GetBoardID());
                sw.WriteLine("主板型号：" + hardwareInfo.GetBoardType());

                sw.WriteLine("CPU序列号：" + hardwareInfo.GetCPUSerialNumber());
                sw.WriteLine("CPU编号：" + hardwareInfo.GetCPUID());
                sw.WriteLine("CPU版本信息：" + hardwareInfo.GetCPUVersion());
                sw.WriteLine("CPU名称信息：" + hardwareInfo.GetCPUName());
                sw.WriteLine("CPU制造厂商：" + hardwareInfo.GetCPUManufacturer());

                sw.WriteLine("物理硬盘序列号：" + hardwareInfo.GetHardDiskSerialNumber());
                sw.WriteLine("磁盘序列号：" + hardwareInfo.GetDiskSerialNumber());

                sw.WriteLine("网卡地址：" + hardwareInfo.GetNetCardMACAddress());
                sw.WriteLine("网卡硬件地址：" + hardwareInfo.GetMacAddress());

                sw.WriteLine("物理内存：" + hardwareInfo.GetPhysicalMemory());

                sw.WriteLine("显卡PNPDeviceID：" + hardwareInfo.GetVideoPNPID());
                sw.WriteLine("声卡PNPDeviceID：" + hardwareInfo.GetSoundPNPID());
                sw.WriteLine("\n\n");

                // 网络信息
                sw.WriteLine("---------  网络信息  ---------");
                NetworkInfo networkInfo = new NetworkInfo();
                sw.WriteLine("IP地址：" + networkInfo.GetIPAddress());
                string[] LocalIpAddress = networkInfo.GetLocalIpAddress();
                foreach (var item in LocalIpAddress)
                {
                    sw.WriteLine("本地ip地址：" + item);
                }
                string[] ExtenalIpAddress = networkInfo.GetExtenalIpAddress();
                foreach (var item in ExtenalIpAddress)
                {
                    sw.WriteLine("外网ip地址：" + item);
                }
                sw.WriteLine("\n\n");

                // 软件信息
                sw.WriteLine("---------  软件信息  ---------");
                Dictionary<string, string> softDictionary = SoftwaresInfo.GetSoftWares();
                // 把软件名、版本号写入文件
                foreach (var item in softDictionary)
                {
                    sw.WriteLine(item.Key + "\t" + item.Value);
                }
                sw.WriteLine("\n\n");


                Console.WriteLine("信息文件保存在：" + Environment.CurrentDirectory + @"\" + filename);
                Console.ReadKey();

                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception e1)
            {
                System.Diagnostics.Debug.WriteLine("Program Main," + e1.Message.ToString());
            }
        }
    }
}
