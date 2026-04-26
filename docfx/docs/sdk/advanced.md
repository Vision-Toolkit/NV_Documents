# SDK 高级功能

本文档介绍 Tachyon SDK 中的高级功能，包括命令系统、节点工厂、节点库提供者、基础设施服务、Shell 和 Dock 布局管理等。

## 命令系统

命令系统提供了一种标准化的方式来定义和执行应用程序命令。

### ICommandHandler

命令处理器接口，所有命令都需要实现此接口：

```csharp
namespace Tachyon.UI.Command;

public interface ICommandHandler
{
    bool CanExecute(IServiceProvider ctx);
    Task ExecuteAsync(IServiceProvider ctx, object[] args, CancellationToken ct);
}
```

### CommandDefinitionAttribute

用于定义命令的元数据：

```csharp
namespace Tachyon.Registry;

[AttributeUsage(AttributeTargets.Class)]
public class CommandDefinitionAttribute(string id, string displayName, string iconKey = "") : Attribute
{
    public string Id { get; } = id.ToLower();
    public string DisplayName { get; } = displayName;
    public string IconKey { get; } = iconKey;
}
```

### 实现命令处理器

```csharp
using Microsoft.Extensions.DependencyInjection;
using Tachyon.Registry;
using Tachyon.UI.Command;

[CommandDefinition(Id, "新建项目")]
public class NewProjectCommandHandler: ICommandHandler
{
    public const string Id = "project.new";
    
    public bool CanExecute(IServiceProvider ctx)
    {
        return true;
    }

    public async Task ExecuteAsync(IServiceProvider ctx, object[] args, CancellationToken ct)
    {
        var scope = ctx.GetRequiredService<IProjectScope>();
        await scope.CreateViewAsync();
    }
}
```

### 命令属性说明

| 属性 | 类型 | 说明 |
|------|------|------|
| `Id` | string | 命令唯一标识符，自动转换为小写 |
| `DisplayName` | string | 命令显示名称 |
| `IconKey` | string | 图标键值（可选） |

---

## 节点工厂

节点工厂负责创建节点实例。

### INodeFactory

节点工厂接口：

```csharp
namespace Tachyon.Registry;

public interface INodeFactory
{
    NodeModel? Create(NodeTypeInfo info);
    NodeModel? Create(string nodeTypeName);
}
```

### NodeTypeInfo

节点类型信息记录：

```csharp
public record NodeTypeInfo(string Name, Type NodeType, string[] Arguments, string Category = "未命名");
```

### RequiresFactoryAttribute

用于标记需要特定工厂的节点：

```csharp
[AttributeUsage(AttributeTargets.Class)]
public class RequiresFactoryAttribute(int key) : Attribute
{
    public int Key { get; } = key;

    public static int GetKey(Type t)
    {
        return t.GetCustomAttribute<RequiresFactoryAttribute>()?.Key ?? 0;
    }
}
```

### 实现节点工厂

```csharp
using Microsoft.Extensions.Logging;
using Tachyon.Graph.Models;
using Tachyon.Registry;

public class DefaultNodeFactory: INodeFactory
{
    private ILogger _logger;
    
    public DefaultNodeFactory(ILogger<DefaultNodeFactory> logger)
    {
        _logger = logger;
    }
    
    public NodeModel? Create(NodeTypeInfo info)
    {
        _logger.LogDebug("Create node use {info}", info);
        return Activator.CreateInstance(info.NodeType) as NodeModel;
    }

    public NodeModel? Create(string nodeTypeName)
    {
        var info = RegistryExtensions.NodeTypes.ToDictionary(x => x.FullName!, x => x);
        var type = info[nodeTypeName];
        return Activator.CreateInstance(type) as NodeModel;
    }
}
```

---

## 节点库提供者

节点库提供者负责提供可用的节点类型信息。

### INodeLibProvider

节点库提供者接口：

```csharp
namespace Tachyon.Registry;

public interface INodeLibProvider
{
    IEnumerable<NodeTypeInfo> Provide();
}
```

### 实现节点库提供者

```csharp
using System.ComponentModel;
using System.Reflection;
using Tachyon.Registry;

public sealed class DefaultNodeLibProvider: INodeLibProvider
{
    public IEnumerable<NodeTypeInfo> Provide()
    {
        var types = RegistryExtensions.NodeTypes;
        foreach (var nodeType in types)
        {
            var category = "未分类";
            var name = nodeType.Name;
            
            var cat = nodeType.GetCustomAttribute<CategoryAttribute>()?.Category;
            if (cat != null) category = cat;
            
            var na = nodeType.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
            if (na != null) name = na;

            var info = new NodeTypeInfo(name, nodeType, [], category);
            yield return info;
        }
    }
}
```

### IToastService

Toast 通知服务接口： @Tachyon.UI.InfraServices.IToastService

---

## Shell

Shell 是应用程序的主框架，管理菜单、工具栏和状态栏。


### 使用示例
[!code-csharp[](../code/SampleExtension/ShellComponent.cs)]

---

## 布局管理

布局管理系统负责管理文档和工具窗口的布局。

布局管理器接口：@Tachyon.UI.Docking.IDockLayoutManager

可停靠项接口：@Tachyon.UI.Docking.IDockItem

工具窗口基类：@Tachyon.UI.Docking.ToolBase

文档基类：@Tachyon.UI.Docking.DocumentBase

预定义的停靠组：@Tachyon.UI.Docking.BasicDockGroups

会话工具接口，用于响应执行会话事件：@Tachyon.UI.Docking.ISessionTool

文档处理器接口，响应文档打开事件：@Tachyon.UI.Docking.IDocumentHandler

### 使用示例

#### 创建工具窗口
[!code-csharp[](../code/SampleExtension/ViewModels/SampleToolViewModel.cs)]

[!code-csharp[](../code/SampleExtension/Views/SampleToolView.axaml)]