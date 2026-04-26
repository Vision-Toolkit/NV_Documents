using Tachyon.Engine;
using Tachyon.Graph;
using Tachyon.Graph.Models;
using Tachyon.Sdk.Extra;
using Tachyon.Sdk.Extra.Graph;

namespace SampleExtension.Nodes;

public sealed class TestCondNode : CondNodeBase
{
    private readonly DataConnector<int> i1;
    private readonly DataConnector<bool> o;

    public TestCondNode()
    {
        Title = "Compare > 50";
        i1 = this.AddInput<int>("num");
        o = this.AddOutput<bool>("v");
    }

    public override async Task ExecuteAsync(INodeExecutionContext session)
    {
        // var c = (int)(session.Read(i1) ?? 0) > 50;
        session.ReadOrDefault(i1, out var vi1);
        session.Write(o, vi1 > 50);
        // return base.ExecuteAsync(session);
    }
}