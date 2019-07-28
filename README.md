# 获取 Windows 操作系统的系统、网络、硬件、软件等信息

博文：[获取 Windows 操作系统的系统、网络、硬件、软件等信息](https://blog.huihut.com/2019/07/28/GetWindowsInfo/)

## 获取的信息

能获得的信息如下（系统、硬件、网络信息已打码）

```
---------  系统信息  ---------
计算机名：***
登录用户名：***
操作系统类型：***


---------  硬件信息  ---------
本机的MAC地址：***
主板序列号：***
主板制造厂商：***
主板编号：***
主板编号：***
主板型号：***
CPU序列号：***
CPU编号：***
CPU版本信息：***
CPU名称信息：***
CPU制造厂商：***
物理硬盘序列号：***
磁盘序列号：***
网卡地址：***
网卡硬件地址：***
物理内存：***
显卡PNPDeviceID：***
声卡PNPDeviceID：***


---------  网络信息  ---------
IP地址：***
本地ip地址：***
本地ip地址：***
外网ip地址：***
外网ip地址：***


---------  软件信息  ---------
GitHub Desktop	2.1.0
Mozilla Firefox 68.0 (x86 en-US)	68.0
Microsoft OneDrive	19.103.0527.0003
Python 3.7.2 (32-bit)	3.7.2150.0
Microsoft Visual Studio Code (User)	1.36.1
***
```

## 硬件网络信息

硬件网络信息是通过 System.Management 里面的类方法获取的，具体类方法可查看官方文档：

[System.Management Namespace](https://docs.microsoft.com/zh-cn/dotnet/api/system.management)

## 软件信息

软件信息是通过读取注册表的方式获取的，所以软件开发使用的话需要验证一下某些安全管家是否会警告。

* 都有的信息：名字（DisplayName）
* 大部分都有的信息：名字（DisplayName）、版本号（DisplayVersion）、发行商（Publisher）、安装日期（InstallDate）
* 比较多信息的如下图：
    ![](https://huihut-img.oss-cn-shenzhen.aliyuncs.com/%E6%B3%A8%E5%86%8C%E8%A1%A8-VMware.png)


### 软件信息在注册表的路径

```
计算机\HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\
计算机\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\
```

### 监控读取注册表

测试了一下读取注册表，360，腾讯管家不会警告，但有些软件（如：[procmon](https://docs.microsoft.com/zh-cn/sysinternals/downloads/procmon)）能监控进程的读取的行为。

![](https://huihut-img.oss-cn-shenzhen.aliyuncs.com/20190328110726.png)