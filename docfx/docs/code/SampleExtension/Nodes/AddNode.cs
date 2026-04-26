using System.ComponentModel;
using Tachyon.Engine;
using Tachyon.Graph;
using Tachyon.Graph.Models;
using Tachyon.Sdk.Extra;

namespace SampleExtension.Nodes;

[Category("Math")]
[DisplayName("加法运算")]
public class AddNode : NodeModel
{
    internal DataConnector<int> a, b, c;

    public AddNode()
    {
        Title = "Add Node";
        a = this.AddInput<int>("a");
        b = this.AddInput<int>("b");
        c = this.AddOutput<int>("c");
    }

    public override Task ExecuteAsync(INodeExecutionContext session)
    {
        session.ReadOrDefault(a, out var va);
        session.ReadOrDefault(b, out var vb);

        session.Write(c, va + vb);

        return base.ExecuteAsync(session);
    }
}