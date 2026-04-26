using Microsoft.Extensions.DependencyInjection;
using SampleExtension.Nodes;
using SampleExtension.ViewModels;
using Tachyon;
using Tachyon.Registry;

namespace SampleExtension;

public class SampleExtension : IHostedExtension
{
    public IServiceCollection ConfigureServices(IServiceCollection services)
    {
        return services.UseSampleExtension();
    }
}

public static class SampleExtensionExtensions
{
    public static IServiceCollection UseSampleExtension(this IServiceCollection services)
    {
        services
            .RegisterNode<AddNode>()
            .RegisterNode<AddNodeWithVis>()
            .RegisterNode<RandomNode>()
            .RegisterNode<DelayNode>()
            .RegisterNode<TestCondNode>()
            .RegisterNode<TriggerNode>()
            .RegisterNode<LiveRandNode>()
            .RegisterNode<WithPropertiesNode>()
            .RegisterNode<SliderNode>();


        services.RegisterShellViewComponent<ShellComponent>();
        services.AddSingleton<SampleToolViewModel>();

        return services;
    }
}