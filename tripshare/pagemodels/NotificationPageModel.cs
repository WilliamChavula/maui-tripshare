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
        var oldNotifications = new ObservableCollection<Notification>(Notifications);

        Notifications.Clear();

        foreach (var item in oldNotifications)
        {
            if (item.NotificationId == notification.NotificationId)
            {
                item.IsRead = true;
            }

            Notifications.Add(item);
        }
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

