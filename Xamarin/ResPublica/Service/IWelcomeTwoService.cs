using System.Threading.Tasks;
using HiRes.Implementation.ViewModel;

namespace HiRes.Interface.Service
{
    public interface IWelcomeTwoService
    {
        Task WelcomeTwo(WelcomeTwoViewModel model);
    }
}

