# ChatRWKV桌面版懒人包
![图片alt](/20230425182102.png)
***
## 说明

本懒人包基于ChatRWKV制作,该项目地址：[https://github.com/BlinkDL/ChatRWKV](https://github.com/BlinkDL/ChatRWKV)

UI使用HandyControl控件库 [开发文档地址](https://handyorg.github.io/handycontrol/)、[GitHub地址](https://github.com/HandyOrg/HandyControl)

之前在知乎发布的版本部分代码和UI是有授权限制的,花了点时间现移除了授权部分的代码和UI,所以UI会和之前不同,功能上并无差别。

先声明当初是想着自己用的,注释什么的基本算没有吧,如果要修改的可能需要花点时间看一下代码。

***
## 编译环境要求

1.Net6.0

2.Visual Studio Community 2022/2019

3.VS安装.Net桌面开发

4.Windows11/10

## 核心部分
Resources/PyFile/Run.py 该文件负责启动ChatRWKV服务
ViewModels/MainViewModel.cs 基本所有的功能操作都在这

***
## 打包程序步骤
1.双击ChatRWKV_PC.sln打开解决方案

2.右键ChatRWKV_PC项目,选择发布

3.添加发布配置文件

4.目标和特定目标都选择文件夹,其它选项默认

5.自行选择其它设置项

6.发布

***
## 协议说明
Apache License 2.0

## 觉得不错的话

![图片alt](/20230425224023.png)
![图片alt](/20230425225459.png)