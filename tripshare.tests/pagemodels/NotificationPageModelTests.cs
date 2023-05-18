namespace tripshare.tests.pagemodels;

public class NotificationPageModelTests : IClassFixture<NotificationsFixture>
{
    private readonly Mock<INotificationService> _service;
    private readonly NotificationsFixture _notificationsFixture;

    public NotificationPageModelTests(NotificationsFixture notificationsFixture)
    {
        _service = new Mock<INotificationService>();
        _notificationsFixture = notificationsFixture;
    }
    
    [Fact]
    public void ShouldCallFilterByAccommodationTypeOnInitialization()
    {
        // Arrange
        _service.Setup(instance => instance.GenerateNotifications().Result)
            .Returns(_notificationsFixture.Notifications);

        // Act
        var sut = new NotificationPageModel(_service.Object);
        sut.Init(new object());

        // Assert
        _service.Verify(
            instance => instance.GenerateNotifications(),
            Times.Once());
        sut.Notifications.Should().HaveCount(5);
    }
}