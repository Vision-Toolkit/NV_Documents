# 节点可视化

本文档介绍如何为节点创建自定义可视化效果。

## 概述

节点可视化允许开发者为节点创建自定义的UI展示效果。通过实现 @IVisualizableNode 接口，可以在节点执行时实时显示数据变化。

### 继承加法节点
[!code-csharp[](../code/SampleExtension/Nodes/AddNodeWithVis.cs)]


### 创建可视化页面

[!code-xml[](../code/SampleExtension/Views/AddVisualizeView.axaml)]