using CommunityToolkit.Mvvm.ComponentModel;
using SampleExtension.Nodes;
using SampleExtension.Views;
using Tachyon.Engine;
using Tachyon.Graph;
using Tachyon.Graph.Models;
using Tachyon.UI.Mvvm;

namespace SampleExtension.ViewModels;

public partial class AddVisualizer: ObservableObject, INodeVisualizer, IViewModelFor<AddVisualizeView>
{
    [ObservableProperty] private string text = "";
    
    public void Dispose()
    {
        // TODO 在此释放托管资源
    }

}