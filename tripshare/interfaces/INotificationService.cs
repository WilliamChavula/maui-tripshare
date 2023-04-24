namespace tripshare.interfaces;

public interface INotificationService
{
    Task<List<Notification>> GenerateNotifications();
}

