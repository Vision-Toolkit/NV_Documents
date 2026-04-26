using Tachyon.Engine;
using Tachyon.Graph;
using Tachyon.Graph.Models;

namespace SampleExtension.Nodes;

public class LiveRandNode : NodeModel
{
    private readonly DataConnector<bool> v;

    public LiveRandNode()
    {
        Title = "Live Rand Bool";
        v = this.AddOutput<bool>("value");
    }

    public override Task ExecuteAsync(INodeExecutionContext session)
    {
        var r = Random.Shared.Next(0, 100) > 50;

        session.Write(v, r);

        return base.ExecuteAsync(session);
    }
}