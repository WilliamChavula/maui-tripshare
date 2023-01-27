namespace tripshare.controls;

public partial class VacationControl : StackLayout
{


    public string VacationImageAvatar
    {
        get => (string)GetValue(VacationImageAvatarProperty);
        set => SetValue(VacationImageAvatarProperty, value);
    }
    public string VacationTypeName
    {
        get => (string)GetValue(VacationTypeNameProperty);
        set => SetValue(VacationTypeNameProperty, value);
    }

    public VacationControl()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty VacationImageAvatarProperty = BindableProperty.Create(
        propertyName: nameof(VacationImageAvatar),
        returnType: typeof(string),
        declaringType: typeof(VacationControl));



    public static readonly BindableProperty VacationTypeNameProperty = BindableProperty.Create(
        propertyName: nameof(VacationTypeName),
        returnType: typeof(string),
        declaringType: typeof(VacationControl));


}
