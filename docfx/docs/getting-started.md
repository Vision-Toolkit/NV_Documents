# 开始开发 扩展

## 创建示例插件项目

为了开始使用NodeVision.SDK开发您的插件，请按照以下步骤创建一个新的类库项目。

### 步骤 1: 创建项目

打开命令行工具（如CMD或PowerShell），并运行以下命令来创建一个名为`ExtHost`的.NET类库项目：

```shell
dotnet new classlib -n ExtHost
```
这将在当前目录下创建一个名为 `ExtHost` 的新文件夹，并在其中初始化一个新的.NET类库项目。


进入您刚刚创建的项目目录：

```shell
cd ExtHost
```
接下来，您需要向项目中添加NodeVision.SDK作为依赖项。

继续在命令行工具中执行以下命令来安装最新版本的NodeVision.SDK：

```shell
dotnet add package FlowEngine.Avalonia --source https://www.myget.org/F/flowengine/api/v3/index.json
```
此命令会从指定的NuGet源 下载并添加 SDK 到您的项目中。


### 步骤 2: 编辑 ExtHost.csproj 文件

接下来需要编辑 `ExtHost.csproj` 文件以启用动态加载并调整包引用设置。请将原有的内容修改为如下所示：




[!code-xml[](code_samples/ExtHost/ExtHost.csproj?highlight=9,13-16)]

完成这些更改后，您的项目配置就完成了，可以继续进行后续开发工作。

## 节点示例

本指南将帮助您理解如何在NodeVision SDK中创建自定义节点，并将其集成到插件项目中。

我们将通过具体的例子：`AddNode` 和 `ConditionFlowNode` 来展示如何实现这些功能。

### MethodNodeBase: AddNode 示例

`AddNode` 是一个简单的加法节点，它接受两个输入值并输出它们的和:

[!code-csharp[](code_samples/ExtHost/Nodes/AddNode.cs)]

+ 设置节点基本属性  
将节点的标题 Title 设置为 "加法"。 ；
使用 `this.CreateInput()` 创建两个输入端口 x 和 y；
使用 `this.CreateInput` 创建一个输出端口 value；
分别初始化所有端口的数据为 1,2,0，以确保在首次运行时有默认值。
+ OnExecute 方法：  
当节点被执行时，此方法会被调用。这里实现了简单的加法操作，将 x 和 y 的数据相加，并将结果存储在 value 中。


### FlowNodeBase：ConditionFlowNode 示例

`ConditionFlowNode` 是一个简单的条件节点，它根据条件来选择执行步骤:

[!code-csharp[](code_samples/ExtHost/Nodes/ConditionFlowNode.cs)]

+ 设置节点基本属性  
将节点的标题 Title 设置为 "条件"。  
使用 `this.CreateFlowInput()` 创建事件输入；
使用 `this.CreateInput(false, "条件")` 创建 条件 输入；
使用 `this.CreateFlowOutput` 创建两个输出分支 True 和 False。
+ OnExecute 方法：  
当节点被执行时，此方法会被调用。当 _cond 端口的执行为 True 时，执行 _trueBranch ，否则执行 _falseBranch。


## 集成节点到插件项目
为了让您的自定义节点能够在 编辑器 中使用，您需要将它们注册到插件系统中。  
新建一个C#文件：

[!code-csharp[](code_samples/ExtHost/Class1.cs)]

在 `Class1` 中，我们需要完成：
+ 实现 @"FlowEngine.Avalonia.Abstractions.IHostedExtension?text=IHostedExtension" 接口，提供插件的基本信息（名称和版本）。
+ 在 @"FlowEngine.Avalonia.Abstractions.IHostedExtension.ConfigureServices*?text=ConfigureServices" 方法中，通过 `services.RegisterNode<T>()` 注册刚才的加法节点

---
通过上述步骤，您已经成功创建并集成了自定义节点到软件中。您可以根据需求进一步扩展这些节点的功能，并添加更多的节点来丰富您的插件。


## 编译与测试插件

完成开发后，下一步是编译并测试您的插件以确保其正常工作。

### 1. 编译项目

执行 `dotnet build`

在命令行工具（如CMD或PowerShell）中，导航到您的项目目录（`ExtHost`），然后执行以下命令：

```shell
dotnet build
```
如果一切正常，您将会看到类似如下的输出：
```
还原完成(0.2)
  ExtHost 已成功 (0.3) → bin\Debug\net9.0\ExtHost.dll

在 0.7 中生成 已成功
```

### 2. 准备

使用软件新建一个名为 `新建项目` 的测试项目。

创建测试脚本
新建一个脚本 `launch.bat`
```sh
F:\Program Files\FlowEngine\bin\Playground\FlowEngine.exe --project "C:\Users\swety\Documents\奥创\Projects\新建项目\project.json" --load_ext "ExtHost\bin\Debug\net9.0\ExtHost.dll" 
```


### 3. 验证功能

双击 launch.bat ，程序将启动并且加载目标插件。
此时新建节点项目之后，你将会在左侧的 节点库 面板 里面见到你开发的节点。

将从节点库中将 AddNode 拖拽至画布，之后点击工具栏上的 测试 按钮：
+ 选中该节点，在属性面板上会见到 value 端口的值从 0 变成了 3。
![s](/images/test_add.png)

### 4. 调试插件
首先在有问题的代码附近添加断点，之后运行主程序，并且将调试器附加到主程序。  
之后按照正常的调试流程进行调试即可。
