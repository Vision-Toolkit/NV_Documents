using Tachyon.Engine.Instructions;
using Tachyon.Graph;
using Tachyon.Graph.Models;

namespace SampleExtension.Nodes;

/// <summary>
/// 流程节点的数据应该只依靠弱引用（或直接的数据源）
/// </summary>
public class TestSubGraphNode: NodeModel, ISubGraphNode
{
    private IDataPort cond;
    public TestSubGraphNode()
    {
        Icon = "Sub";
        Title = "子图";
    }
    public override IInstruction ToInstruction()
    {
        return new SubGraphCall()
        {
            SubGraph = SubGraph,
            Condition = cond
        };
    }

    public INodeGraph SubGraph { get; set; }
}