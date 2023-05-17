namespace tripshare.models;

public class Notification
{
    public Guid NotificationId { get; private set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public bool IsRead { get; set; }
    public DateTime NotificationTime { get; set; }
}

