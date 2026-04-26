using IconPacks.Avalonia.Lucide;
using SampleExtension.Views;
using Tachyon.Controls;
using Tachyon.UI.Docking;

namespace SampleExtension.ViewModels;

public class SampleToolViewModel : ToolBase<SampleToolView>
{
    public SampleToolViewModel()
    {
        Header = "测试页面";
        DefaultGroup = BasicDockGroups.Right;
        Icon = LucideIconModel.Create(PackIconLucideKind.Tag);
    }
}