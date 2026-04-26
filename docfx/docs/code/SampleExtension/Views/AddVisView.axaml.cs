using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.ComponentModel;
using Tachyon.Engine;
using Tachyon.UI.Mvvm;

namespace SampleExtension.Views;

public partial class AddVisView : UserControl
{
    public AddVisView()
    {
        InitializeComponent();
    }
}

public partial class AddVisViewModel: ObservableObject, INodeVisualizer, IViewModelFor<AddVisView>
{
    [ObservableProperty] private string text;
    
    public void Dispose()
    {
        // TODO 在此释放托管资源
    }
}