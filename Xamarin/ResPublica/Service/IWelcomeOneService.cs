using System.Threading.Tasks;
using HiRes.Implementation.ViewModel;

namespace HiRes.Interface.Service
{
    public interface IWelcomeOneService
    {
        Task WelcomeOne(WelcomeOneViewModel model);
    }
}

