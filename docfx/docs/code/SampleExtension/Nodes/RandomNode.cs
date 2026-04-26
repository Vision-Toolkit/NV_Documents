using Tachyon.Engine;
using Tachyon.Graph;
using Tachyon.Graph.Models;

namespace SampleExtension.Nodes;

public class RandomNode : NodeModel
{
    private readonly IDataWrapper i;

    public RandomNode()
    {
        Title = "Random Node";
        i = this.AddOutput<int>("value", true);
    }

    public override Task ExecuteAsync(INodeExecutionContext session)
    {
        session.Write(i, Random.Shared.Next(100));
        return base.ExecuteAsync(session);
    }
}