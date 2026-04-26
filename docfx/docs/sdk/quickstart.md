# 快速开始

本文档提供节点开发的快速上手指南。


## 环境准备

1. **安装 .NET 9.0 SDK**
   - 从 [Microsoft 官方网站](https://dotnet.microsoft.com/download) 下载并安装

2. **安装程序**

---

## 创建扩展项目

### 1. 新建项目 
新建项目 
```bash
dotnet new classlib -n SampleExtension -o `SampleExtension`
```
### 2. 更新项目文件

修改 `SampleExtension.csproj` 文件：
[!code-xml[](../code/SampleExtension/SampleExtension.csproj)]

### 3. 创建 Feature.targets (可选)
创建 `Feature.targets` 文件：
[!code-xml[](../code/SampleExtension/Feature.targets)]

### 4. 添加 SDK 的引用
添加 `Directory.Build.props` 文件
[!code-json[](../code/Directory.Build.props)]

---

## 实现第一个节点

参考 [节点开发示例](./examples.md)

## 构建和测试

### 1. 构建扩展

```bash
dotnet build
```

### 2. 运行应用

通过命令行参数加载你的扩展并启动应用，在节点库中查找你的自定义节点。

```bash
App.exe --load_ext "bin\Debug\net9.0\SampleExtension.dll"
```
