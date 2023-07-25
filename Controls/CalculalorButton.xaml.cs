using Microsoft.Maui.Graphics;

namespace QuickDigits.Controls;

public partial class CalculalorButton : Border
{
    public string Text { get; set; }
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create
        (
            nameof(Text), typeof(string),
            typeof(CalculalorButton),            
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: TextPropertyChange
            );

    public Color ButtonBackGroundColor { get; set; }
    public static readonly BindableProperty ButtonBackGroundColorProperty =
        BindableProperty.Create(
            nameof(ButtonBackGroundColor),
            typeof(Color),
            typeof(CalculalorButton),
            propertyChanged: ButtonBackGroundColorPropertyChange);
   
    private static void ButtonBackGroundColorPropertyChange(BindableObject bindable, object oldValue, object newValue)
    {
       var control = (CalculalorButton)bindable;
        control.BackgroundColor = (Color)newValue;
        control.Stroke = (Color)newValue;
    }

    private static void TextPropertyChange(BindableObject bindable, object oldValue, object newValue)
    {
       var control = (CalculalorButton)bindable;
       control.buttomLabel.Text = newValue.ToString();      
    }

    public CalculalorButton()
    {
        InitializeComponent();
    }
}