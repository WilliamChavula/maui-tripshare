namespace tripshare.pagemodels;

public class NotificationPageModel : FreshBasePageModel
{
    private readonly INotificationService service;


    public NotificationPageModel(INotificationService notificationService)
    {
        service = notificationService;
    }

    public ObservableCollection<Notification> Notifications { get; set; }

    public Command<Notification> MarkAsReadCommand => new(notification =>
    {
        var idx = Notifications.IndexOf(notification);
        Notifications.Remove(notification);

        notification.IsRead = true;

        Notifications.Insert(idx, notification);
    });

    public Command CloseModalAsyncCommand => new(() =>
    {
        CoreMethods.PopPageModel(modal: true);
    });

    public override async void Init(object initData)
    {
        var notifications = await service.GenerateNotifications();

        var ordered = notifications.OrderByDescending((arg) => arg.NotificationTime);

        Notifications = new(ordered);
    }
}

