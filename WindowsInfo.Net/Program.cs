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
            FileStream fs = new FileStream("info.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            
            // 获取软件信息
            Dictionary<string, string> softDictionary = SoftwaresInfo.GetSoftWares();
            // 把软件名、版本号写入文件
            foreach (var item in softDictionary)
            {
                sw.WriteLine(item.Key + "\t" + item.Value);
            }

            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}
