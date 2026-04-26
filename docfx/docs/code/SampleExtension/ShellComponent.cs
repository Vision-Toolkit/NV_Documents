using CommunityToolkit.Mvvm.Input;
using IconPacks.Avalonia.Lucide;
using Microsoft.Extensions.DependencyInjection;
using SampleExtension.ViewModels;
using Tachyon.Controls;
using Tachyon.Controls.Toast;
using Tachyon.Project;
using Tachyon.Sdk.Extra;
using Tachyon.UI.Docking;
using Tachyon.UI.InfraServices;
using Tachyon.UI.Shell;

namespace SampleExtension;

internal class ShellComponent : IShellViewComponent
{
    private readonly IToastService _toastService;

    public ShellComponent(IToastService toastService)
    {
        _toastService = toastService;
    }

    public void OnLoaded(IShellViewModel shell)
    {
        var node = shell.GetOrAddMenuNode("测试");
        node.Children.Add(new MenuNode
        {
            Header = "测试",
            Children =
            [
                new MenuNode
                {
                    Icon = LucideIconModel.Create(PackIconLucideKind.Bug),
                    Header = "子项",
                    Command = new RelayCommand(() => { _toastService.CreateToast("你点击了菜单子项").Show(); })
                },
                new MenuNode
                {
                    Icon = LucideIconModel.Create(PackIconLucideKind.Package),
                    Header = "打开页面",
                    Command = new RelayCommand(
                        () =>
                        {
                            IProjectScope.Current!.GetRequiredService<IDockLayoutManager>()
                                .AddViewEx<SampleToolViewModel>();
                        }, () => IProjectScope.Current != null)
                }
            ]
        });
    }

    public void OnClosed(IShellViewModel shell)
    {
        // nop
    }
}