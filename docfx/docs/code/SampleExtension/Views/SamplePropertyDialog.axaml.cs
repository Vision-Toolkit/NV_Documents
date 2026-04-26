using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SampleExtension.Nodes;

namespace SampleExtension.Views;

public partial class SamplePropertyDialog : Window
{
    public SamplePropertyDialog()
    {
        InitializeComponent();
    }
}

public partial class SamplePropertyViewModel : ObservableObject
{
    [ObservableProperty] private string text;

    public required PropertyNodeWithDialog Node { get; init; }

    [RelayCommand]
    private void Apply()
    {
        Node.Text = Text;
    }
}