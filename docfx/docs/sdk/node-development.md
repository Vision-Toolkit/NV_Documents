# 节点开发指南

本文档介绍如何开发自定义节点。

## 节点基类

所有自定义节点必须继承 @Tachyon.Graph.Models.NodeModel 基类：

---

## 端口定义

### 添加输入端口

```csharp
a = this.AddInput<int>("a");
b = this.AddInput<int>("b");
```

### 添加输出端口

```csharp
c = this.AddOutput<int>("c");
```

---

## 节点分类

使用属性对节点进行分类：

```csharp
[Category("Math")]
[DisplayName("加法运算")]
public class AddNode : NodeModel
{
    // 节点实现
}
```

---

## 端口数据的读写

### 在 ExecuteAsync 内读写：

使用 @Tachyon.Engine.INodeExecutionContext 里的 `Read` 和 `Write` 方法读写端口数据。

或者使用 @Tachyon.Sdk.Extra.ExecutionContextExtensions 中的 `ReadOrDefault<T>(INodeExecutionContext, DataConnector<T>, out T)` 以更方便的方式读取端口数据：

[!code-csharp[](../code/SampleExtension/Nodes/AddNode.cs#L23-L31)]

### 在执行方法外读取

使用 @Tachyon.Sdk.Extra.ExecutionContextExtensions 中的 `ReadOrGet<T>(DataConnector<T>, Func<object>?)`

## 节点类型

### 1. 普通计算节点

在 `ExecuteAsync` 方法中执行计算逻辑。详见 [普通计算节点](./examples.md#普通计算节点)。

### 2. 带UI内容的节点

通过重写 `Content` 属性提供自定义UI。详见 [带ui内容的节点](./examples.md#带ui内容的节点)。

### 3. 条件节点

使用条件连接器实现流程控制。详见 [流程控制节点](./examples.md#流程控制节点)。

---

## Live执行支持

### RaiseNodeUpdated

- 在 Live 模式下，当节点的属性发生变化时，需要调用 `RaiseNodeUpdated()` 方法通知系统节点已更新，**暂不支持端口数量变化**。

```csharp
partial void OnValueChanged(int value)
{
    if (Parent.ReadOnly)
    {
        return;
    }
    RaiseNodeUpdated();
}
```

### 注意事项

- 检查 `Parent.ReadOnly` 属性，避免在只读模式下触发更新

---

## 节点注册

### 注册节点

```csharp
services.RegisterNode<AddNode>();
```

### 程序菜单

- 添加自定义程序菜单项，详见 [示例](./examples.md)。

```csharp
services.RegisterShellViewComponent<ShellComponent>();
```