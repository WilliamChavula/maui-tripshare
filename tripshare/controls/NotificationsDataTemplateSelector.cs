namespace tripshare.controls;

public class NotificationsDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate ReadNotification { get; set; }
    public DataTemplate UnReadNotification { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var notification = item as Notification;

        return notification.IsRead ? ReadNotification : UnReadNotification;
    }
}

