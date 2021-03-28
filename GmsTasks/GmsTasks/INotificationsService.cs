using System.Threading.Tasks;

namespace GmsTasks
{
    public interface INotificationsService
    {
        Task<string> GetToken();
    }
}
