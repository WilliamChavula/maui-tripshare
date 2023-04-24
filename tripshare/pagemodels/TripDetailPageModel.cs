namespace tripshare.pagemodels;

[AddINotifyPropertyChangedInterface]
public class TripDetailPageModel : FreshBasePageModel
{
    public override void Init(object initData)
    {
        if (initData != null)
        {
            Destination = initData as Destination;
        }
    }

    public Destination Destination { get; set; }

    public bool IsDark { get; set; }

    public Command NavigateToHomePageCommand => new(async () =>
    {
        await CoreMethods.PopPageModel();
    });
}