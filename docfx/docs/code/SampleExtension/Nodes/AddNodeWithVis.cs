using System.ComponentModel;
using SampleExtension.Views;
using Tachyon.Engine;
using Tachyon.Sdk.Extra;

namespace SampleExtension.Nodes;

[DisplayName("AddNodeWithVis")]
public class AddNodeWithVis: AddNode, IVisualizableNode
{
    public AddNodeWithVis()
    {
        Title = "加法可视化";
    }

    public INodeVisualizer? Visualizer { get; set; }
    public void UpdateVisualizer()
    {
        Visualizer ??= new AddVisViewModel();
        if (Visualizer is AddVisViewModel vm)
        {
            vm.Text = $"{a.ReadOrGet()}+{b.ReadOrGet()}={c.ReadOrGet()}";
        }
    }
}