## 为新建的节点创建别名/分组

在上一章内容中，我们完成了自定义节点的使用，默认情况下，节点全都会在节点库的 未分类 文件夹中。

### 添加 Category DisplayName 特性

[!code-xml[](code_samples/ExtHost/Nodes/AddNode.cs.1?highlight=7)]
打开 上次创建的 `AddNode.cs` 文件，在 `public class AddNode : MethodNodeBase` 上添加 `[Category("测试"),DisplayName("加法")]` 
即可让加法节点出现在名为 `测试` 的文件夹内。

