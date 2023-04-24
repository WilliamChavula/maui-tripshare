namespace tripshare.controls;

public partial class DestinationCardControl : ContentView
{
    public static readonly BindableProperty DestinationNameProperty = BindableProperty.Create(
        nameof(DestinationName),
        typeof(string),
        typeof(DestinationCardControl)
        );

    public static readonly BindableProperty DestinationAddressProperty = BindableProperty.Create(
        nameof(DestinationAddress),
        typeof(string),
        typeof(DestinationCardControl)
        );
    public static readonly BindableProperty DestinationChargeAmountProperty = BindableProperty.Create(
        nameof(DestinationChargeAmount),
        typeof(double),
        typeof(DestinationCardControl)
        );
    public static readonly BindableProperty DestinationIsFavoriteProperty = BindableProperty.Create(
        nameof(DestinationIsFavorite),
        typeof(bool),
        typeof(DestinationCardControl)
        );
    public static readonly BindableProperty DestinationRatingProperty = BindableProperty.Create(
        nameof(DestinationRating),
        typeof(double),
        typeof(DestinationCardControl)
        );
    public static readonly BindableProperty DestinationImageProperty = BindableProperty.Create(
        nameof(DestinationImage),
        typeof(string),
        typeof(DestinationCardControl)
        );


    public DestinationCardControl()
    {
        InitializeComponent();
    }

    public string DestinationName
    {
        get => (string)GetValue(DestinationNameProperty);
        set => SetValue(DestinationNameProperty, value);
    }
    public string DestinationAddress
    {
        get => (string)GetValue(DestinationAddressProperty);
        set => SetValue(DestinationAddressProperty, value);
    }
    public double DestinationChargeAmount
    {
        get => (double)GetValue(DestinationChargeAmountProperty);
        set => SetValue(DestinationChargeAmountProperty, value);
    }
    public bool DestinationIsFavorite
    {
        get => (bool)GetValue(DestinationIsFavoriteProperty);
        set => SetValue(DestinationIsFavoriteProperty, value);
    }
    public double DestinationRating
    {
        get => (double)GetValue(DestinationRatingProperty);
        set => SetValue(DestinationRatingProperty, value);
    }
    public string DestinationImage
    {
        get => (string)GetValue(DestinationImageProperty);
        set => SetValue(DestinationImageProperty, value);
    }
}
