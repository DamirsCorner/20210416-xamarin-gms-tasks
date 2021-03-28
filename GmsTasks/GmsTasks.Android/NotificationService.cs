using Firebase.Messaging;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(GmsTasks.Droid.NotificationService))]
namespace GmsTasks.Droid
{
    public class NotificationService : INotificationsService
    {
        public async Task<string> GetToken()
        {
            var result = await FirebaseMessaging.Instance.GetToken().ToAwaitableTask();
            return result.ToString();
        }
    }
}