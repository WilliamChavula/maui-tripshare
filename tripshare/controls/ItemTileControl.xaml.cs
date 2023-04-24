namespace tripshare.controls;

public partial class ItemTileControl : Grid
{
    public static readonly BindableProperty ItemIconProperty = BindableProperty.Create(
        nameof(ItemIcon),
        typeof(string),
        typeof(ItemTileControl)
    );

    public static readonly BindableProperty ItemLabelProperty = BindableProperty.Create(
        nameof(ItemLabel),
        typeof(string),
        typeof(ItemTileControl)
    );

    public ItemTileControl()
    {
        InitializeComponent();
    }

    public string ItemIcon
    {
        get => (string) GetValue(ItemIconProperty);
        set => SetValue(ItemIconProperty, value);
    }

    public string ItemLabel
    {
        get => (string) GetValue(ItemLabelProperty);
        set => SetValue(ItemLabelProperty, value);
    }
}