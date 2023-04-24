namespace tripshare.services;

public class NotificationService : INotificationService
{
    private List<Notification> notifications = new();

    public Task<List<Notification>> GenerateNotifications()
    {
        return Task.FromResult(notifications);
    }
}

