using Tachyon.Engine;
using Tachyon.Sdk.Extra.Graph;

namespace SampleExtension.Nodes;

public class DelayNode : CondNodeBase
{
    public DelayNode()
    {
        Title = "Delay";
    }

    public override async Task ExecuteAsync(INodeExecutionContext session)
    {
        await Task.Delay(100);
    }
}