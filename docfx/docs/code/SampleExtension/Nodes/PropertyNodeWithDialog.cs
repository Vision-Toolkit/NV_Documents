using System.Text.Json;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using SampleExtension.Views;
using Tachyon.Engine;
using Tachyon.Graph;
using Tachyon.Graph.Models;

namespace SampleExtension.Nodes;

public class PropertyNodeWithDialog : NodeModel
{
    private readonly DataConnector<string> str;

    public PropertyNodeWithDialog()
    {
        Title = "自定义属性窗口";
        str = this.AddOutput<string>("Value");
    }

    public string Text { get; set; }

    public override void LoadConfig(byte[] data)
    {
        Text = JsonSerializer.Deserialize<string>(data) ?? "";
    }

    public override byte[] SaveConfig()
    {
        return JsonSerializer.SerializeToUtf8Bytes(Text);
    }

    public override Task ExecuteAsync(INodeExecutionContext session)
    {
        session.Write(str, Text);
        return base.ExecuteAsync(session);
    }

    public override void OnDoubleClick()
    {
        new SamplePropertyDialog
        {
            DataContext = new SamplePropertyViewModel
            {
                Node = this,
                Text = Text
            }
        }.ShowDialog(
            (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow);
    }
}