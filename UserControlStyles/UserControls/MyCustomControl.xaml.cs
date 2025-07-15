namespace UserControlStyles.UserControls;

public partial class MyCustomControl : ContentView
{
    public static readonly BindableProperty UpperTextProperty =
	    BindableProperty.Create(nameof(UpperText), typeof(string), typeof(MyCustomControl), "Up", propertyChanged: OnUpperTextChanged);

    public static readonly BindableProperty UpperRectColorProperty = 
        BindableProperty.Create(nameof(UpperRectColor), typeof(Brush), typeof(MyCustomControl), new SolidColorBrush(Colors.AliceBlue), propertyChanged: OnUpperRectColorChanged);

    public MyCustomControl()
	{
		InitializeComponent();
        // Set default values for the properties (or default style)
        UpTextLabel.Text = UpperText;
        UpRectangle.Fill = UpperRectColor;
    }

    private static void OnUpperTextChanged(BindableObject d, object oldValue, object newValue)
    {
        var control = (MyCustomControl)d;
        if(control == null || control.UpTextLabel == null) // Might be called before InitializeComponent
            return;
        control.UpTextLabel.Text = (string)newValue;
    }

    private static void OnUpperRectColorChanged(BindableObject d, object oldValue, object newValue)
    {
        var control = (MyCustomControl)d;
        if (control == null || control.UpRectangle == null) // Might be called before InitializeComponent
            return;
        control.UpRectangle.Fill = (Brush)newValue;
    }

    public string UpperText
    {
        get { return (string)GetValue(UpperTextProperty); }
        set { SetValue(UpperTextProperty, value); }
    }

    public Brush UpperRectColor
    {
        get { return (Brush)GetValue(UpperRectColorProperty); }
        set { SetValue(UpperRectColorProperty, value); }
    }


}