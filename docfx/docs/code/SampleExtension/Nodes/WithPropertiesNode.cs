using Tachyon.Engine;
using Tachyon.Extra;
using Tachyon.Extra.PropertyModel;
using Tachyon.Graph;
using Tachyon.Graph.Models;
using Tachyon.PropertyModel;
using Tachyon.Sdk.Extra.Graph;

namespace SampleExtension.Nodes;

public enum ColorMode
{
    Red,
    Green,
    Blue,
    Grayscale
}

public class WithPropertiesNode : PropertiedNode
{
    private readonly IObjectProperty<bool> _boolProperty;
    private readonly IObjectProperty<double> _doubleProperty;
    private readonly IObjectProperty<ColorMode> _enumProperty;
    private readonly IObjectProperty<int> _intProperty;
    private readonly DataConnector<string> _resultCon;
    private readonly IObjectProperty<string> _textProperty;
    private readonly IObjectProperty<(double lower, double upper)> rangeProperty;

    public WithPropertiesNode()
    {
        Title = "With Properties Test";

        _resultCon = this.AddOutput<string>("结果");
        _boolProperty = this.AddBoolProperty("布尔");
        _textProperty = this.AddTextProperty("文本", "Hello");
        _enumProperty = this.AddEnumProperty("颜色模式", ColorMode.Red);
        _intProperty = this.AddNumberProperty("整数值", 50,
            variantType: NumberVariantType.Slider,
            minimum: 0, maximum: 100);
        _doubleProperty = this.AddNumberProperty("浮点值", 0.5,
            variantType: NumberVariantType.NumericUpDown,
            minimum: 0.0, maximum: 1.0);

        rangeProperty = this.AddRangeProperty("范围", 0, 10, 0, 100);

        AttachPropertyEventListener();
    }

    public override Task ExecuteAsync(INodeExecutionContext session)
    {
        var str =
            $"Bool: {_boolProperty.TValue} Text: {_textProperty.TValue}, Mode: {_enumProperty.TValue}, Int: {_intProperty.TValue}, Double: {_doubleProperty.TValue}, Range: {rangeProperty.TValue}";
        session.Write(_resultCon, str);

        return base.ExecuteAsync(session);
    }
}