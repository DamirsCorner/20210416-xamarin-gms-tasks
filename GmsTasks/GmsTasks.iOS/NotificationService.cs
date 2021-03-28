using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(GmsTasks.iOS.NotificationService))]
namespace GmsTasks.iOS
{
    public class NotificationService : INotificationsService
    {
        public Task<string> GetToken()
        {
            throw new NotImplementedException();
        }
    }
}