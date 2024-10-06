using DIPS.FastTrak.Models;

namespace DIPS.FastTrak.Services
{
    public interface INotificationsService
    {
        List<Notification> Notifications { get; }
    }

    public class NotificationsService : INotificationsService
    {
        public List<Notification> Notifications => [
            new Notification { Title = "Notat sendt til Arena", CreatedAt = DateTime.Now.AddHours(-1) },
            new Notification { Title = "LabData oppdatert", CreatedAt = DateTime.Now.AddHours(-4) }
        ];
    }
}
