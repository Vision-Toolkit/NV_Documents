# 自定义节点属性面板

> [!NOTE]
> 由于本教程涉及界面设计等操作，推荐使用 Visual Studio 2022 或 Rider 进行开发。


主程序已经提供了一些基本输入输出端口属性的显示、编辑功能。如果有更高级的属性编辑需求，可以选择自定义节点属性面板。

## 在我们开始之前
本示例假定您对以下主题有基本了解：
+ 关于 C# 和 [XAML](https://docs.avaloniaui.net/docs/get-started/test-drive/) 的一些基础知识
+ 什么是 [MVVM -模式](https://github.com/AvaloniaUI/Avalonia.Samples/blob/main/src/Avalonia.Samples/MVVM/BasicMvvmSample)（模型-视图-视图模型）及其工作原理
+ 什么是 [Command](https://github.com/AvaloniaUI/Avalonia.Samples/blob/main/src/Avalonia.Samples/MVVM/CommandSample)，它是如何工作的
+ 什么是 [ObservableCollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=net-8.0) 以及它如何工作

## CommunityToolkit.MVVM
[CommunityToolkit.MVVM](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/)-package是MVVM-Apps的众多第三方包之一。我们将在这个示例中使用它，因为它非常轻量级。此外，它还带有内置的源代码生成器，可以让我们编写更少的样板代码。

如果您想了解有关这些源生成器如何工作的更多信息，请参阅[此处](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/generators/overview)和[此处](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/generators/overview)。

## 目标

在本教程中，我们将为加法节点添加 可变数量的输入端口 功能。


### 建立节点属性控件


> [!TIP]
> 如果你觉得属性面板的空间太小，你甚至可以在属性面板里添加一个按钮，然后在按钮事件里面弹出新的窗口来承载更多内容！！
## 编译与测试插件

参见 [## 编译与测试插件](getting-started.md)

<p align="center">效果预览</p>
