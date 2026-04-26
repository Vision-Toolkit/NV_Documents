# 节点开发示例

本文档提供常见节点类型的完整实现示例。

---

## 普通计算节点

[!code-csharp[](../code/SampleExtension/Nodes/AddNode.cs)]

## 带UI内容的节点

通过重写 `Content` 属性提供自定义UI。

[!code-csharp[](../code/SampleExtension/Nodes/SliderNode.cs)]

---

## 流程控制节点

继承 @Tachyon.Sdk.Extra.Graph.CondNodeBase 并实现自定义执行逻辑。

[!code-csharp[](../code/SampleExtension/Nodes/TestCondNode.cs)]


### 延时节点实现
[!code-csharp[](../code/SampleExtension/Nodes/DelayNode.cs)]

---
## 带有属性面板的节点

A. 通过继承 `Properties` 属性提供自定义属性面板

[!code-csharp[](../code/SampleExtension/Nodes/WithPropertiesNode.cs)]

B. 自定义 双击事件 和 加载保存方法 来实现自定义的属性窗口

[!code-csharp[](../code/SampleExtension/Nodes/PropertyNodeWithDialog.cs)]

---

## 注册到节点库

[!code-csharp[](../code/SampleExtension/SampleExtension.cs)]
