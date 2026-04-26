using Microsoft.Extensions.DependencyInjection;
using Tachyon.Engine;
using Tachyon.Graph;
using Tachyon.Graph.Models;
using Tachyon.Project;
using Tachyon.Sdk.Extra;
using Tachyon.Sdk.Extra.Graph;
using Tachyon.Sdk.Extra.Models;
using Tachyon.UI.InfraServices;

namespace SampleExtension.Nodes;

public class TriggerNode : CondNodeBase
{
    private readonly CondConnector branch;

    private bool last;

    private readonly DataConnector<bool> signal;

    public TriggerNode()
    {
        Title = "Trigger Node";
        signal = this.AddInput<bool>("signal");
        branch = this.AddCondOutput("triggered");
    }

    private IToastService? _toastManager => IProjectScope.Current?.GetService<IToastService>();

    public override async Task ExecuteAsync(INodeExecutionContext session)
    {
        session.ReadOrDefault(signal, out var current);
        var triggered = last != current;

        session.Set(branch, triggered);
        last = current;
    }
}