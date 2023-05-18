namespace tripshare.tests.fixtures;

public class NotificationsFixture
{
    public List<Notification> Notifications { get; set; }

    public NotificationsFixture()
    {
        Notifications = GenerateNotifications();
    }

    private List<Notification> GenerateNotifications()
    {
        const int notificationSize = 5;
        var titleCount = new Random().Next(3, 11);
        var sentenceCount = new Random().Next(1, 4);
        
        return new Faker<Notification>()
            .RuleFor(obj => obj.Title, f => f.Random.Words(titleCount))
            .RuleFor(obj => obj.Description, f => f.Lorem.Sentences(sentenceCount))
            .RuleFor(obj => obj.ImageUrl, f => f.Person.Avatar)
            .RuleFor(obj => obj.IsRead, f => false)
            .RuleFor(obj => obj.NotificationTime, f => f.Date.Between(DateTime.Now.AddDays(-7), DateTime.Now))
            .Generate(notificationSize).ToList();
    }
}