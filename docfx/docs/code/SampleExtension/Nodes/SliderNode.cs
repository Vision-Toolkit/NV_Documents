using System.ComponentModel;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using Tachyon.Engine;
using Tachyon.Graph;
using Tachyon.Graph.Models;

namespace SampleExtension.Nodes;

[Category("UI")]
[DisplayName("滑块")]
public partial class SliderNode : NodeModel
{
    private readonly DataConnector<int> o;

    [ObservableProperty] private int value = 10;

    public SliderNode()
    {
        Title = "Slider";
        o = this.AddOutput<int>("v");
    }

    public override object? Content => new Slider
    {
        [!RangeBase.ValueProperty] = new Binding
        {
            Path = nameof(Value),
            Source = this,
            Delay = 500
        },
        Maximum = 100,
        Minimum = 0
    };

    public override async Task ExecuteAsync(INodeExecutionContext session)
    {
        session.Write(o, Value);
    }

    partial void OnValueChanged(int value)
    {
        if (Parent.ReadOnly) return;
        RaiseNodeUpdated();
    }
}