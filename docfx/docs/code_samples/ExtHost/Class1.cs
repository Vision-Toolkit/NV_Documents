using ExtHost.Nodes;
using FlowEngine.Abstractions;
using FlowEngine.Avalonia.Abstractions;
using FlowEngine.Avalonia.Abstractions.Misc;
using Microsoft.Extensions.DependencyInjection;

namespace ExtHost;

public class Class1 : IHostedExtension
{
    public string PluginName => typeof(Class1).Assembly.GetName().Name;
    public Version Version => typeof(Class1).Assembly.GetName().Version;


    public void ConfigureServices(IServiceCollection services)
    {
        services.RegisterNode<AddNode>();
    }
}