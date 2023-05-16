using Bogus;

namespace tripshare.services;

public class NotificationService : INotificationService
{
    private readonly List<Notification> notifications = new();
    const int NOTIFICATION_SIZE = 10;

    public async Task<List<Notification>> GenerateNotifications()
    {
        var notificationItems = await LoadNotifications();
        foreach (var item in notificationItems)
        {
            notifications.Add(item);
        }
        return notifications;
    }

    private static Task<List<Notification>> LoadNotifications()
    {
        var titleCount = new Random().Next(3, 11);
        var sentenceCount = new Random().Next(1, 4);
        var notifications = new Faker<Notification>()
            .StrictMode(true)
            .RuleFor(obj => obj.Title, f => f.Random.Words(titleCount))
            .RuleFor(obj => obj.Description, f => f.Lorem.Sentences(sentenceCount))
            .RuleFor(obj => obj.ImageUrl, f => f.Person.Avatar)
            .RuleFor(obj => obj.IsRead, f => false)
            .RuleFor(obj => obj.NotificationTime, f => f.Date.Between(DateTime.Now.AddDays(-7), DateTime.Now))
            .Generate(NOTIFICATION_SIZE).ToList();

        return Task.FromResult(notifications);
    }
}

