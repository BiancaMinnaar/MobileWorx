using System.Threading.Tasks;
using HiRes.Implementation.ViewModel;

namespace HiRes.Interface.Service
{
    public interface IWelcomeService
    {
        Task Welcome(WelcomeViewModel model);
    }
}

